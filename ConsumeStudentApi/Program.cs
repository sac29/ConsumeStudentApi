using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeStudentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeEventSync objsync = new ConsumeEventSync();
             //   objsync.GetAllStudentData();
                //  objsync.GetStudentDataById(2);
                objsync.PostStudentData();
          //      objsync.UpdateStudentData(2);
          //  objsync.DeleteStudent(2);
        }
    }
}
