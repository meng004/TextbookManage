using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Applications.Impl;
using TextbookManage.ViewModels;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.IRepositories;

namespace TextbookManage.Applicaitons.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AutoMapperForTextbookView()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.TextbookRepository(uow);
            var book = repo.First(t => t.Num == 401);
            var view = adapter.Adapt<TextbookView>(book);
            StringAssert.EndsWith(view.Edition, "版");
            StringAssert.EndsWith(view.PrintCount, "次印刷");
        }

        [TestMethod]
        public void AutoMapperForTextbook()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.TextbookRepository(uow);
            var book = repo.First(t => t.Num == 2330);
            var view = adapter.Adapt<TextbookView>(book);
            var edition = view.Edition.Substring(1, view.Edition.Length - 2).ConvertToInt();
            var printCount = view.PrintCount.Substring(1, view.PrintCount.Length - 4).ConvertToInt();
            var result = adapter.Adapt<Textbook>(view);
            Assert.IsTrue(result.Edition > 0);
            Assert.IsTrue(result.PrintCount > 0);

        }

        [TestMethod]
        public void AutoMapperForDeclarationBaseView()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.DeclarationRepository(uow);
            var declaration = repo.GetAll().First();
            var view = adapter.Adapt<DeclarationBaseView>(declaration);
            Assert.IsNotNull(view.ProfessionalClassName);
        }

        [TestMethod]
        public void AutoMapperForDeclarationQueryView()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.DeclarationRepository(uow);
            var declaration = repo.GetAll().First();
            var view = adapter.Adapt<DeclarationForQueryView>(declaration);
            Assert.IsNotNull(view.ProfessionalClassName);
        }

        [TestMethod]
        public void AutoMapperForDeclarationApprovalView()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.DeclarationRepository(uow);
            var declaration = repo.GetAll().First();
            var view = adapter.Adapt<DeclarationForApprovalView>(declaration);
            Assert.IsNotNull(view.ProfessionalClassName);
        }

        [TestMethod]
        public void AutoMapperForDeclarationTeachingTaskView()
        {
            var adapter = new Infrastructure.TypeAdapter.AutoMapperTypeAdapter();
            var uow = ServiceLocator.Current.GetInstance<IRepositoryContext>();
            var repo = new Repositories.DeclarationRepository(uow);
            var declaration = repo.GetAll().First();
            var view = adapter.Adapt<DeclarationForTeachingTaskView>(declaration);
            Assert.IsNotNull(view.ProfessionalClassName);
        }

        [TestMethod]
        public void GetMaxTerm()
        {
            var app = new TermAppl();
            var term = app.GetMaxTerm();
            Assert.AreSame("2011-2012-2", term.YearTerm);
        }

        /// <summary>
        /// 将字符串转为阿拉伯数字
        /// 只处理千位以下
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int GetArab(string number)
        {
            string ChnNumString = number;

            if (ChnNumString == "零")
            {
                return 0;
            }
            //处理未加数词的情况
            if (ChnNumString != string.Empty)
            {
                if (ChnNumString[0].ToString() == "十")
                {
                    ChnNumString = "一" + ChnNumString;
                }
            }

            ChnNumString = ChnNumString.Replace("零", string.Empty);
            //去除所有的零
            int result = 0;
            int index = ChnNumString.IndexOf("千");
            if (index != -1)
            {
                result +=
                this.HZToInt(ChnNumString.Substring(0, index)) * 1000;
                ChnNumString =
                ChnNumString.Remove(0, index + 1);
            }
            index = ChnNumString.IndexOf("百");
            if (index != -1)
            {
                result +=
                this.HZToInt(ChnNumString.Substring(0, index)) * 100;
                ChnNumString =
                ChnNumString.Remove(0, index + 1);
            }
            index = ChnNumString.IndexOf("十");
            if (index != -1)
            {
                result +=
                this.HZToInt(ChnNumString.Substring(0, index)) * 10;
                ChnNumString =
                ChnNumString.Remove(0, index + 1);
            }
            if (ChnNumString != string.Empty)
            {
                result += this.HZToInt(ChnNumString);
            }
            return result;
        }

        [TestMethod]
        public void GetArabTest()
        {
            var result = GetArab("九百二十七");
            Assert.AreEqual(927, result);
        }

        /// <summary>
        /// 中文汉字转阿拉伯数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int HZToInt(string str)
        {
            switch (str)
            {
                case "一":
                default:
                    return 1;
                case "二":
                    return 2;
                case "三":
                    return 3;
                case "四":
                    return 4;
                case "五":
                    return 5;
                case "六":
                    return 6;
                case "七":
                    return 7;
                case "八":
                    return 8;
                case "九":
                    return 9;
            }
        }


        [TestMethod]
        public void HzToIntTest()
        {
            var result = HZToInt("九");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void GetStudentNameByNum()
        {
            var app = new StudentAppl();
            var name = app.GetNameByNum("123");
            Assert.AreEqual("没有该学生", name);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var app = ServiceLocator.Current.GetInstance<IInventoryAppl>();
            var result = app.GetStorages("60D6E947-EC9C-4A0A-AEA6-26673C046B3C");
            Assert.IsTrue(result.Count() > 0);
        }
        //[TestMethod]
        //public void TestMethod2()
        //{
        //    var app = ServiceLocator.Current.GetInstance<IInventoryAppl>();
        //    var result = app.GetPresses("60D6E947-EC9C-4A0A-AEA6-26673C046B3C");
        //    Assert.IsTrue(result.Count() > 0);
        //}

        [TestMethod]
        public void TestMethod3()
        {
            var app = ServiceLocator.Current.GetInstance<IDropClassBookAppl>();
            var result = app.GetRecipientsByTextbookId("", "");
            int count = result.Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var app = ServiceLocator.Current.GetInstance<IInventoryAppl>();
            var result = app.GetInventory("1", "75599D75-3AB7-4E9A-B7AA-00183C0E9590");
            Assert.IsTrue(result.InventoryId == "0");
        }

        [TestMethod]
        public void CreateStockRecord()
        {
            var inventory = new Inventory
            {
                InventoryId = 1,
                InventoryCount = 100,
                Storage_Id = 1,
                Textbook_Id = Guid.NewGuid(),
                ShelfNumber = "D4-3"
            };

            Domain.InventoryService.CreateStockRecord<InStockRecord>(inventory, "甲", 100);

            Assert.IsTrue(inventory.StockRecords.Count > 0);
        }

        [TestMethod]
        public void SubmitInStockForAdd()
        {
            var app = ServiceLocator.Current.GetInstance<IInventoryAppl>();
            var view = new InventoryView
            {
                InventoryId = "0",
                StorageId = "1",
                TextbookId = "98F77E4D-6D9B-4368-9AE4-001E8EFD4586",
                InventoryCount = 0,
                ShelfNumber = "d3-6"
            };
            var result = app.SubmitInStock(view, "256", "dongxb");
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void SubmitInStockForModify()
        {
            var app = ServiceLocator.Current.GetInstance<IInventoryAppl>();
            var view = new InventoryView
            {
                InventoryId = "2",
                StorageId = "1",
                TextbookId = "98F77E4D-6D9B-4368-9AE4-001E8EFD4586",
                InventoryCount = 256,
                ShelfNumber = "d3-6"
            };
            var result = app.SubmitInStock(view, "256", "dongxb");
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
