using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Services.Test
{
    [TestClass]
    public class SchoolServiceTest
    {
        [TestMethod]
        public void GetAllSchools()
        {
            var service = ServiceLocator.Current.GetInstance<ISchoolService>();
            //var service = new SchoolService();
            var result = service.GetAll();
            var result1 = service.GetAll();
            Assert.IsTrue(result.Count() > 1);
        }

        [TestMethod]
        public void GetAllSchoolsByService()
        {
            //var service = new TextbookManage.Services.Jw.SchoolService();
            var service = ServiceLocator.Current.GetInstance<ISchoolService>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = service.GetAll();
            sw.Stop();
            var time1 = sw.Elapsed;

            sw.Restart();
            var result1 = service.GetAll();
            sw.Stop();
            var time2 = sw.Elapsed;
            //两次耗时相差10倍
            var r = time1.Ticks / time2.Ticks;
            Assert.IsTrue(r >100);

            Assert.IsTrue(result1.Count() > 1);
        }

        [TestMethod]
        public void CacheAopIsSuccess()
        {
            using (SchoolService.SchoolServiceClient client = new SchoolService.SchoolServiceClient())
            {                
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = client.GetAll();
                sw.Stop();
                var time1 = sw.Elapsed;
                
                sw.Restart();
                var result1 = client.GetAll();
                sw.Stop();
                var time2 = sw.Elapsed;

                //两次耗时相差10倍
                var r = time1.Ticks / time2.Ticks;
                Assert.IsTrue(r > 10);
                
                
                Assert.IsTrue(result1.Count() > 1);
            }            
        }
    }
}
