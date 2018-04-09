using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeStudentApi
{
    class ConsumeEventSync
    {
        public void GetAllStudentData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:52967/api/students"); //URI  
            
                dynamic dynamicJson = JsonConvert.DeserializeObject(result);
                foreach (var item in dynamicJson)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}\n", item.ID, item.FirstName,
                        item.LastName, item.Gender,item.NoOfSubjects);
                }
            }
        }
        public void GetStudentDataById(int id) //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:52967/api/students/"+id); //URI  
               // Console.WriteLine(result);
                dynamic dynamicJson = JsonConvert.DeserializeObject(result);
                //foreach (var item in dynamicJson)
                //{
                    Console.WriteLine("{0} {1} {2} {3} {4}\n", dynamicJson.ID, dynamicJson.FirstName,
                    dynamicJson.LastName, dynamicJson.Gender, dynamicJson.NoOfSubjects);
                //}
            }
        }
        public void PostStudentData()
        {
             using(var client = new WebClient())
            {
                Student obj = new Student();
                obj.ID = 2;
                obj.FirstName = "sam";
                obj.LastName = "smith";
                obj.Gender = "male";
                obj.NoOfSubjects = 6;
                client.Headers.Add("Content-Type:application/json");
                var result = client.UploadString("http://localhost:52967/api/students", JsonConvert.SerializeObject(obj));
                Console.WriteLine(result);
            }

        }
        public void UpdateStudentData(int id)
        {
            using (var client = new WebClient())
            {
                Student obj = new Student();
                
                obj.FirstName = "sami";
                obj.LastName = "smith";
                obj.Gender = "male";
                obj.NoOfSubjects = 6;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:52967/api/students?id="+id,"PUT", JsonConvert.SerializeObject(obj));
                Console.WriteLine(result);
            }
        }
        public void DeleteStudent(int id)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            var result = client.UploadString("http://localhost:52967/api/students?id=" + id, "Delete", "");
            Console.WriteLine(result);
        }
    }
}
