using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Domain
{
   public class ReleaseBookService
    {
       /// <summary>
       ///  创建退还班级记录
       /// </summary>
       /// <param name="releaseRecordId"></param>
       /// <param name="classId"></param>
       /// <returns></returns>
       public static StudentReleaseRecord CreateClassDropReleaseRecord(Guid releaseRecordId,Guid classId)
       {
           var stuRel = new StudentReleaseRecord() 
           {
               ReleaseRecordId=releaseRecordId,
               Class_Id = classId
           };

           return stuRel;
       }

       /// <summary>
       ///  创建退还学生记录
       /// </summary>
       /// <param name="releaseRecordId"></param>
       /// <param name="studentId"></param>
       /// <returns></returns>
       public static StudentReleaseRecord CreateStudentDropReleaseRecord(Guid releaseRecordId, Guid studentId)
       {
           var stuRel = new StudentReleaseRecord()
           {
               ReleaseRecordId = releaseRecordId,
               Student_Id = studentId
           };

           return stuRel;
       }


       /// <summary>
       /// 创建退还时的库存变更记录
       /// </summary>
       /// <param name="stockRecordId"></param>
       /// <returns></returns>
       public static InStockRecord CreateStockRecord(int stockRecordId)
       {
           var stockRecord = new InStockRecord() { StockRecordId = stockRecordId };

           return stockRecord;
       }

       /// <summary>
       /// 发放修改库存数量
       /// </summary>
       /// <param name="inventoryId"></param>
       /// <param name="stockCount"></param>
       /// <returns></returns>
       public static Inventory CreatInventoryAtRelease(int inventoryId,int stockCount)
       {
           var inventoryRepo = ServiceLocator.Current.GetInstance<IInventoryRepository>();
           var inventory = new Inventory()
               {
                   InventoryId = inventoryId,
                   InventoryCount = inventoryRepo.First(i => i.InventoryId == inventoryId).InventoryCount - stockCount
               };
           return inventory;
       }
       /// <summary>
       ///  退还修改库存数量
       /// </summary>
       /// <param name="inventoryId"></param>
       /// <param name="stockCount"></param>
       /// <returns></returns>
       public static Inventory CreatInventoryAtDrop(int inventoryId, int stockCount)
       {
           var inventoryRepo = ServiceLocator.Current.GetInstance<IInventoryRepository>();
           var inventory = new Inventory()
           {
               InventoryId = inventoryId,
               InventoryCount = inventoryRepo.First(i => i.InventoryId == inventoryId).InventoryCount + stockCount
           };
           return inventory;
       }
       /// <summary>
       /// 创建出库记录
       /// </summary>
       /// <param name="stockRecordId"></param>
       /// <param name="inventoryId"></param>
       /// <param name="releaseCount"></param>
       /// <param name="operatorPerson"></param>
       /// <returns></returns>
       public static OutStockRecord CreateOutStockRecord(int inventoryId, int releaseCount,DateTime stockDate, string operatorPerson)
       {
           var outStockRecord=new OutStockRecord
               {
                   Inventory_Id = inventoryId,
                   StockCount = releaseCount,
                   StockDate = stockDate,
                   Operator = operatorPerson,
                   IsInStock = false
               };
           return outStockRecord;
       }
        /// <summary>
        /// 创建发放记录
        /// </summary>
        /// <param name="releaseRecordId"></param>
        /// <param name="stockRecordId"></param>
        /// <param name="textbookId"></param>
        /// <param name="booksellerId"></param>
        /// <param name="schoolId"></param>
        /// <param name="releaseCount"></param>
        /// <param name="studentId"></param>
        /// <param name="classId"></param>
        /// <param name="student"></param>
        /// <returns></returns>
       public static StudentReleaseRecord CreateReleaseRecord(Guid releaseRecordId,int stockRecordId,Guid textbookId,Guid booksellerId,Guid schoolId,int releaseCount,Guid studentId,Guid classId,Student student)
       {
           var releaseRecord = new StudentReleaseRecord
               {
                   ReleaseRecordId = releaseRecordId,
                   StockRecord_Id = stockRecordId,
                   Textbook_Id = textbookId,
                   Bookseller_Id = booksellerId,
                   School_Id = schoolId,
                   Class_Id = classId,
                   ReleaseCount = releaseCount,
                   Student_Id = studentId,
                   Student = student
               };

           return releaseRecord;
       }
    }
}
