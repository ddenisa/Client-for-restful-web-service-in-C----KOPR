using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestClient
{
    public class Connections
    {
       
        public static string getOneById(int id)
        {
            string result = "";
            string endPoint = @"http://127.0.0.1:8080/recepty/" + id.ToString();
            //string jsonpost = JsonConvert.SerializeObject(recept);
            string jsonpost = "";
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.GET, postData: jsonpost, ContentType: "application/json");
           /* try
            {*/
                var json = client.MakeRequest();
                result = json.ToString();
           /* } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
            return result;
        }

        public static string findByName(string name)
        {

            string endPoint = @"http://127.0.0.1:8080/recepty/findByName";
            //string jsonpost = JsonConvert.SerializeObject(id);
            Console.WriteLine("CO SA K***** DEJE?");
            Console.WriteLine(endPoint);
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: name, ContentType: "application/json");

            var json = client.MakeRequest();
            return json;
           /* string result = "";
            string endPoint = @"http://127.0.0.1:8080/recepty/findByName";
            string jsonpost = JsonConvert.SerializeObject(name);
            Console.WriteLine(jsonpost.ToString());
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.GET, postData: jsonpost, ContentType: "application/json");
            /* try
             {*/
           /* var json = client.MakeRequest();
            result = json.ToString();*/
            /* } catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/
           // return result;
        }

        public static string findByResources(List<Surovina> suroviny)
        {

            string endPoint = @"http://127.0.0.1:8080/recepty/findByResources";
            string jsonpost = JsonConvert.SerializeObject(suroviny);
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "application/json");

            var json = client.MakeRequest();
            Console.WriteLine(json);
            return json;
            /* string result = "";
             string endPoint = @"http://127.0.0.1:8080/recepty/findByName";
             string jsonpost = JsonConvert.SerializeObject(name);
             Console.WriteLine(jsonpost.ToString());
             var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.GET, postData: jsonpost, ContentType: "application/json");
             /* try
              {*/
            /* var json = client.MakeRequest();
             result = json.ToString();*/
            /* } catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/
            // return result;
        }

        /*   public static void delete(int id)
           {
               string endPoint = @"http://127.0.0.1:8080/recepty/" + id.ToString() + "/del";
               //string jsonpost = JsonConvert.SerializeObject(id);
               Console.WriteLine("CO SA K***** DEJE?");
               Console.WriteLine(endPoint);
               var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.GET, postData: "", ContentType: "application/json");

               var json = client.MakeRequest();
                   //Console.WriteLine(json.ToString());

           }*/

        public static void delete(int id)
        {
            string endPoint = @"http://127.0.0.1:8080/recepty/";
            //string jsonpost = JsonConvert.SerializeObject(id);
            Console.WriteLine("CO SA K***** DEJE?");
            Console.WriteLine(endPoint);
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.DELETE, postData: id.ToString(), ContentType: "application/json");

            var json = client.MakeRequest();
            //Console.WriteLine(json.ToString());

        }

        public static void update(Recept recept)
        {
            string endPoint = @"http://127.0.0.1:8080/recepty/updateById";
            string jsonpost = JsonConvert.SerializeObject(recept);
            Console.WriteLine("update printing!");
            Console.WriteLine(jsonpost.ToString());
            Console.WriteLine("update printing!");
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "application/json");
                var json = client.MakeRequest();
           

        }

        public static int upload(Recept recept)
        {
            int returnValue = -1;
            string endPoint = @"http://127.0.0.1:8080/recepty/";
            string jsonpost = JsonConvert.SerializeObject(recept);
            Console.WriteLine(jsonpost.ToString());
            var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "application/json");
            
            //Error upload for debugging error handling: 
            //var client = new RestClientClass(endpoint: endPoint, method: HttpVerb.POST, postData: jsonpost, ContentType: "");

                var json = client.MakeRequest();
                //Console.WriteLine(json.ToString());
                returnValue = Convert.ToInt32( json.ToString());            
            return returnValue;
            
        }
    }
}
