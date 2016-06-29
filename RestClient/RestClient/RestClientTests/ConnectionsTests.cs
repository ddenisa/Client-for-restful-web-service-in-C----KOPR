using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClient.Tests
{
    [TestClass()]
    public class ConnectionsTests
    {
        [TestMethod()]
        public void getOneByIdTest()
        {
            var expected = @"{""id"":1,""suroviny"":[{""nazov"":""mrkva"",""mnozstvo"":10.5,""jednotka"":""kg""},{""nazov"":""zeler"",""mnozstvo"":11.0,""jednotka"":""g""}],""nazov"":""peceny pes"",""postup"":""Upec vsetko spolu"",""autor"":""janik""}";
            var result = Connections.getOneById(1);
            Assert.AreEqual(expected, result);
            var expectedId2 = @"{""id"":2,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""}";
            result = Connections.getOneById(2);
            Assert.AreEqual(expectedId2, result);
            var expectedId3 = @"{""id"":3,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""},{""nazov"":""malina"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""}";
            result = Connections.getOneById(3);
            Assert.AreEqual(expectedId3, result);
            //Assert.Fail();
            for (int i = 0; i < 10; i++)
            {
                object value3 = null; // Used to store the return value
                var thread = new Thread(
                  () =>
                  {
                      value3 = Connections.getOneById(3); // Publish the return value
                  });

                object value2 = null; // Used to store the return value
                var thread2 = new Thread(
                  () =>
                  {
                      value2 = Connections.getOneById(2); // Publish the return value
                  });
                thread.Start();
                thread2.Start();
                thread.Join();
                thread2.Join();
                Assert.AreEqual(expectedId2, value2);
                Assert.AreEqual(expectedId3, value3);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(WebException))]
        public void getOneByIdTest_Failed()
        {
            var result = Connections.getOneById(int.MaxValue);
        }

        [TestMethod()]
        public void findByNameTest()
        {

            var expectedPes = @"[{""id"":1,""suroviny"":[{""nazov"":""mrkva"",""mnozstvo"":10.5,""jednotka"":""kg""},{""nazov"":""zeler"",""mnozstvo"":11.0,""jednotka"":""g""}],""nazov"":""peceny pes"",""postup"":""Upec vsetko spolu"",""autor"":""janik""},{""id"":2,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""},{""id"":3,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""},{""nazov"":""malina"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""}]";
            for (int i = 0; i < 10; i++)
            {
                object value1 = null; // Used to store the return value
                var thread1 = new Thread(
                  () =>
                  {
                      value1 = Connections.findByName("pes"); // Publish the return value
                  });

                object value4 = null; // Used to store the return value
                var thread4 = new Thread(
                  () =>
                  {
                      value4 = Connections.findByName(" pes"); // Publish the return value
                  });

                object value3 = null; // Used to store the return value
                var thread3 = new Thread(
                  () =>
                  {
                      value3 = Connections.findByName("pes"); // Publish the return value
                  });

                object value2 = null; // Used to store the return value
                var thread2 = new Thread(
                  () =>
                  {
                      value2 = Connections.findByName(" pes"); // Publish the return value
                  });
                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread1.Join();
                thread2.Join();
                thread3.Join();
                thread4.Join();
                Assert.AreEqual(expectedPes, value1);
                Assert.AreEqual(expectedPes, value2);
                Assert.AreEqual(expectedPes, value3);
                Assert.AreEqual(expectedPes, value4);
                Assert.AreEqual("[]", Connections.findByName("Bu"));
            }

        }

        [TestMethod()]
        public void findByResourcesTest()
        {
            Trace.Write(Connections.findByName("peceny pes"));
            //ystem.Diagnostics.Debug.WriteLine();
            //Assert.AreEqual("[", "]");
            for (int i = 1; i < 50; i++)
            {
                object result1 = @"[{""id"":1,""suroviny"":[{""nazov"":""mrkva"",""mnozstvo"":10.5,""jednotka"":""kg""},{""nazov"":""zeler"",""mnozstvo"":11.0,""jednotka"":""g""}],""nazov"":""peceny pes"",""postup"":""Upec vsetko spolu"",""autor"":""janik""}]";
                object result2 = @"[{""id"":2,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""},{""id"":3,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""},{""nazov"":""malina"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""}]";
                object result3 = @"[]";
                object result4 = @"[]";
                List<Surovina> suroviny = new List<Surovina>();
                suroviny.Add(new Surovina("mrkva", 10.6, "kg"));
                suroviny.Add(new Surovina("zeler", 11, "g"));
                List<Surovina> suroviny2 = new List<Surovina>();
                suroviny2.Add(new Surovina("jablko", 10, "kg"));
                suroviny2.Add(new Surovina("hruska", 11, "mg"));
                suroviny2.Add(new Surovina("malina", 40, "mg"));
                List<Surovina> suroviny3 = new List<Surovina>();
                suroviny3.Add(new Surovina("mrkva", 9, "kg"));
                suroviny3.Add(new Surovina("zeler", 11, "g"));
                List<Surovina> suroviny4 = new List<Surovina>();
                suroviny4.Add(new Surovina("mrkva", 10.6, "g"));
                suroviny4.Add(new Surovina("zeler", 11, "g"));

                object value1 = null; // Used to store the return value
                var thread1 = new Thread(
                  () =>
                  {
                      value1 = Connections.findByResources(suroviny); // Publish the return value
                  });
                object value2 = null; // Used to store the return value
                var thread2 = new Thread(
                  () =>
                  {
                      value2 = Connections.findByResources(suroviny2); // Publish the return value
                  });
                object value3 = null; // Used to store the return value
                var thread3 = new Thread(
                  () =>
                  {
                      value3 = Connections.findByResources(suroviny3); // Publish the return value
                  });
                object value4 = null; // Used to store the return value
                var thread4 = new Thread(
                  () =>
                  {
                      value4 = Connections.findByResources(suroviny4); // Publish the return value
                  });

                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread1.Join();
                thread2.Join();
                thread3.Join();
                thread4.Join();

                Assert.AreEqual(result1, value1);
                Assert.AreEqual(result2, value2);
                Assert.AreEqual(result3, value3);
                Assert.AreEqual(result4, value4);
            }
            Assert.AreEqual("", "");

            //Test je podchyteny v QUI, nezbehne ak je to prazdne!

            /*List<Surovina> suroviny5 = new List<Surovina>();
            object value5 = Connections.findByResources(suroviny5);
            Assert.AreEqual("[]", suroviny5);*/

        }

        [TestMethod()]
        [ExpectedException(typeof(WebException))]
        public void findByResourcesTest_ERROR()
        {
            List<Surovina> suroviny = null;

            object value1 = Connections.findByResources(suroviny); // Publish the return value
            //
        }

        [TestMethod()]
        public void deleteTest()
        {
            List<Surovina> suroviny = new List<Surovina>();
            suroviny.Add(new Surovina("TEST", 999, "bg"));
            suroviny.Add(new Surovina("TEST", 666, "fs"));
            Recept recept = new Recept(suroviny, "PECENY TEST", "Upec vsetko spolu", "TESTER");

            for (int i = 0; i < 500; i++)
            {
                object value1 = null; // Used to store the return value
                var thread1 = new Thread(
                  () =>
                  {
                      value1 = Connections.upload(recept); // Publish the return value
                  });
                object value2 = null; // Used to store the return value
                var thread2 = new Thread(
                  () =>
                  {
                      value2 = Connections.upload(recept); // Publish the return value
                  });
                object value3 = null; // Used to store the return value
                var thread3 = new Thread(
                  () =>
                  {
                      value3 = Connections.upload(recept); // Publish the return value
                  });
                object value4 = null; // Used to store the return value
                var thread4 = new Thread(
                  () =>
                  {
                      value4 = Connections.upload(recept); // Publish the return value
                  });
                object value5 = null; // Used to store the return value
                var thread5 = new Thread(
                  () =>
                  {
                      value5 = Connections.upload(recept); // Publish the return value
                  });
                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread5.Start();
                thread1.Join();
                thread2.Join();
                thread3.Join();
                thread4.Join();
                thread5.Join();
                var t1 = new Thread(() =>
                {
                    Connections.delete(Convert.ToInt32(value1));
                });
                var t2 = new Thread(() =>
                {
                    Connections.delete(Convert.ToInt32(value2));
                });
                var t3 = new Thread(() =>
                {
                    Connections.delete(Convert.ToInt32(value3));
                });
                var t4 = new Thread(() =>
                {
                    Connections.delete(Convert.ToInt32(value4));
                });
                var t5 = new Thread(() =>
                {
                    Connections.delete(Convert.ToInt32(value5));
                });
                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t5.Start();
                t1.Join();
                t2.Join();
                t3.Join();
                t4.Join();
                t5.Join();
            }
            object result = @"[{""id"":1,""suroviny"":[{""nazov"":""mrkva"",""mnozstvo"":10.5,""jednotka"":""kg""},{""nazov"":""zeler"",""mnozstvo"":11.0,""jednotka"":""g""}],""nazov"":""peceny pes"",""postup"":""Upec vsetko spolu"",""autor"":""janik""},{""id"":2,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""},{""id"":3,""suroviny"":[{""nazov"":""jablko"",""mnozstvo"":10.0,""jednotka"":""kg""},{""nazov"":""hruska"",""mnozstvo"":11.0,""jednotka"":""mg""},{""nazov"":""malina"",""mnozstvo"":11.0,""jednotka"":""mg""}],""nazov"":""vareny pes"",""postup"":""Uvar vsetko spolu"",""autor"":""Janko Hrasko""}]";
            Assert.AreEqual(result, Connections.findByName("*"));
        }

        [TestMethod()]
        [ExpectedException(typeof(WebException))]
        public void deleteTestFailed()
        {
            Connections.delete(int.MaxValue);
        }

        [TestMethod()]
        public void updateTest()
        {
            for (int m = 0; m < 500; m++)
            { 
            List<Surovina> suroviny1 = new List<Surovina>();
            for (int i = 1; i < 4; i++)
            {
                suroviny1.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
            }
            List<Surovina> suroviny2 = new List<Surovina>();
            for (int i = 5; i < 10; i++)
            {
                suroviny2.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
            }
            List<Surovina> suroviny3 = new List<Surovina>();
            for (int i = 15; i < 20; i++)
            {
                suroviny3.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
            }
            List<Surovina> suroviny4 = new List<Surovina>();
            for (int i = 25; i < 30; i++)
            {
                suroviny4.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
            }
            List<Surovina> suroviny5 = new List<Surovina>();
            for (int i = 35; i < 40; i++)
            {
                suroviny5.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
            }

            List<Recept> recepty = new List<Recept>();
            recepty.Add(new Recept(suroviny1, "fdsfasdf", "fsdfsefsfs", "jflksf"));
            recepty.Add(new Recept(suroviny2, "freq", "fsd4234fsefsfs", "jf32rfslksf"));
            recepty.Add(new Recept(suroviny3, "fdsfafs4esdf", "fsdf42 32 sefsfs", "jf4324lksf"));
            recepty.Add(new Recept(suroviny4, "fdsf fs 4asdf", "fs r23dfsefsfs", "jflk r32 sf"));
            recepty.Add(new Recept(suroviny5, "fds r32 fasdf", "fsdf r23 r2 sefsfs", "j r23 flksf"));

            var id1 = Connections.upload(recepty[0]);
            var id2 = Connections.upload(recepty[1]);
            var id3 = Connections.upload(recepty[2]);
            var id4 = Connections.upload(recepty[3]);
            var id5 = Connections.upload(recepty[4]);

            recepty[0].nazov = "FJDASLK";
            recepty[1].nazov = "re2ewf";
            recepty[2].nazov = "432rf";
            recepty[3].nazov = "FJDA324 SLK";
            recepty[4].nazov = "FJDfw 4  wfwa w fASLK";

            recepty[0].id = id1;
            recepty[1].id = id2;
            recepty[2].id = id3;
            recepty[3].id = id4;
            recepty[4].id = id5;

            // Used to store the return value
            var thread1 = new Thread(
              () =>
              {
                  Connections.update(recepty[0]); // Publish the return value
              });

            var thread2 = new Thread(
              () =>
              {
                  Connections.update(recepty[1]); // Publish the return value
              });
            // Used to store the return value
            var thread3 = new Thread(
              () =>
              {
                  Connections.update(recepty[2]); // Publish the return value
              });
            // Used to store the return value
            var thread4 = new Thread(
              () =>
              {
                  Connections.update(recepty[3]); // Publish the return value
              });
            // Used to store the return value
            var thread5 = new Thread(
              () =>
              {
                  Connections.update(recepty[4]); // Publish the return value
              });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();

            var result1 = Connections.getOneById(Convert.ToInt32(id1));
            var result2 = Connections.getOneById(Convert.ToInt32(id2));
            var result3 = Connections.getOneById(Convert.ToInt32(id3));
            var result4 = Connections.getOneById(Convert.ToInt32(id4));
            var result5 = Connections.getOneById(Convert.ToInt32(id5));
            List<Recept> receptyToCMP = new List<Recept>();
            receptyToCMP.Add(new Recept(result1));
            receptyToCMP.Add(new Recept(result2));
            receptyToCMP.Add(new Recept(result3));
            receptyToCMP.Add(new Recept(result4));
            receptyToCMP.Add(new Recept(result5));
            Assert.AreEqual(receptyToCMP[0].print(), recepty[0].print());
            Assert.AreEqual(receptyToCMP[1].print(), recepty[1].print());
            Assert.AreEqual(receptyToCMP[2].print(), recepty[2].print());
            Assert.AreEqual(receptyToCMP[3].print(), recepty[3].print());
            Assert.AreEqual(receptyToCMP[4].print(), recepty[4].print());
                Connections.delete(id1);
                Connections.delete(id2);
                Connections.delete(id3);
                Connections.delete(id4);
                Connections.delete(id5);
            }

        }

        [TestMethod()]
        public void uploadTest()
        {
            for (int m = 0; m < 500; m++)
            {
                List<Surovina> suroviny1 = new List<Surovina>();
                for (int i = 1; i < 4; i++)
                {
                    suroviny1.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
                }
                List<Surovina> suroviny2 = new List<Surovina>();
                for (int i = 5; i < 10; i++)
                {
                    suroviny2.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
                }
                List<Surovina> suroviny3 = new List<Surovina>();
                for (int i = 15; i < 20; i++)
                {
                    suroviny3.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
                }
                List<Surovina> suroviny4 = new List<Surovina>();
                for (int i = 25; i < 30; i++)
                {
                    suroviny4.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
                }
                List<Surovina> suroviny5 = new List<Surovina>();
                for (int i = 35; i < 40; i++)
                {
                    suroviny5.Add(new Surovina("chlieb" + i.ToString(), i * 10, "kg" + i.ToString()));
                }

                List<Recept> recepty = new List<Recept>();
                recepty.Add(new Recept(suroviny1, "fdsfasdf", "fsdfsefsfs", "jflksf"));
                recepty.Add(new Recept(suroviny2, "freq", "fsd4234fsefsfs", "jf32rfslksf"));
                recepty.Add(new Recept(suroviny3, "fdsfafs4esdf", "fsdf42 32 sefsfs", "jf4324lksf"));
                recepty.Add(new Recept(suroviny4, "fdsf fs 4asdf", "fs r23dfsefsfs", "jflk r32 sf"));
                recepty.Add(new Recept(suroviny5, "fds r32 fasdf", "fsdf r23 r2 sefsfs", "j r23 flksf"));

                object value1 = null; // Used to store the return value
                var thread1 = new Thread(
                  () =>
                  {
                      value1 = Connections.upload(recepty[0]); // Publish the return value
                  });
                object value2 = null; // Used to store the return value
                var thread2 = new Thread(
                  () =>
                  {
                      value2 = Connections.upload(recepty[1]); // Publish the return value
                  });
                object value3 = null; // Used to store the return value
                var thread3 = new Thread(
                  () =>
                  {
                      value3 = Connections.upload(recepty[2]); // Publish the return value
                  });
                object value4 = null; // Used to store the return value
                var thread4 = new Thread(
                  () =>
                  {
                      value4 = Connections.upload(recepty[3]); // Publish the return value
                  });
                object value5 = null; // Used to store the return value
                var thread5 = new Thread(
                  () =>
                  {
                      value5 = Connections.upload(recepty[4]); // Publish the return value
              });
                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread5.Start();
                thread1.Join();
                thread2.Join();
                thread3.Join();
                thread4.Join();
                thread5.Join();
                var result1 = Connections.getOneById(Convert.ToInt32(value1));
                var result2 = Connections.getOneById(Convert.ToInt32(value2));
                var result3 = Connections.getOneById(Convert.ToInt32(value3));
                var result4 = Connections.getOneById(Convert.ToInt32(value4));
                var result5 = Connections.getOneById(Convert.ToInt32(value5));
                List<Recept> receptyToCMP = new List<Recept>();
                receptyToCMP.Add(new Recept(result1));
                receptyToCMP.Add(new Recept(result2));
                receptyToCMP.Add(new Recept(result3));
                receptyToCMP.Add(new Recept(result4));
                receptyToCMP.Add(new Recept(result5));
                Assert.AreEqual(receptyToCMP[0].print(), recepty[0].print());
                Assert.AreEqual(receptyToCMP[1].print(), recepty[1].print());
                Assert.AreEqual(receptyToCMP[2].print(), recepty[2].print());
                Assert.AreEqual(receptyToCMP[3].print(), recepty[3].print());
                Assert.AreEqual(receptyToCMP[4].print(), recepty[4].print());
                Connections.delete(Convert.ToInt32(value1));
                Connections.delete(Convert.ToInt32(value2));
                Connections.delete(Convert.ToInt32(value3));
                Connections.delete(Convert.ToInt32(value4));
                Connections.delete(Convert.ToInt32(value5));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void uploadTestFailed()
        {
            Connections.upload(new Recept());
        }
    }
}