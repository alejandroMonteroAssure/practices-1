using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Text;

namespace RefactoringExerciseI.ApprovalTest
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main();
            string output = fakeoutput.ToString();

            Approvals.Verify(output);
        }
    }
}