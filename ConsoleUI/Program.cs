using System;
using System.Linq.Expressions;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IsCompleteTest();
            AssignmentTest();  
            //AssignmentListTest();  
        }

        private static void AssignmentListTest()
        {
            AssignmentListManager assignmentListManager = new AssignmentListManager(
                                        new EfAssignmentListDal());
            foreach (var assignmentList in assignmentListManager.GetAll())
            {
                Console.WriteLine(assignmentList.Name);
            }
        }

        private static void AssignmentTest()
        {
            AssignmentManager assignmentManager = new AssignmentManager(
                            new EfAssignmentDal());

            var result = assignmentManager.GetAssignmentDetails();

            if(result.Success)
            {
                foreach (var assignment in result.Data)
                {
                    Console.WriteLine(assignment.Message + "/" + assignment.AssignmentName + "/" + assignment.AssignmentListName + "/" + assignment.IsCompleted);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

          
        }

        private static void IsCompleteTest()
        {
            AssignmentManager assignmentManager = new AssignmentManager(
                            new EfAssignmentDal());
            var assignment = assignmentManager.IsComplete(new Guid("94BC36AD-4DC0-475D-9F17-093614A392D9"));  
        }
    }
}