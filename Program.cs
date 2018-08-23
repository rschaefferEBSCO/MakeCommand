using System.Text;

namespace MakeCommand
{
	/// <summary>
	/// This assumes a file in the same directory called "Tests.txt" that is a list of all tests to make,
	/// one test per line. The code deals with empty lines and the header "Test Case", so they do not need 
	/// to be removed.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			StringBuilder aDebugCommand = new StringBuilder("-browser Chrome -project EHOST ");
			StringBuilder aLegacyCommand = new StringBuilder("-i EHOST ");
			StringBuilder aTestJob = new StringBuilder();

			using (System.IO.StreamReader aFile = new System.IO.StreamReader("Tests.txt"))
			{
				string aLine;
				int aCounter = 1;

				while ((aLine = aFile.ReadLine()) != null)
					if (!string.IsNullOrWhiteSpace(aLine) && (aLine != "Test Case"))
					{
						aDebugCommand.Append("-testcaseid");
						aDebugCommand.Append(aCounter);
						aDebugCommand.Append(" ");
						aDebugCommand.Append(aLine);
						aDebugCommand.Append(" ");

						aLegacyCommand.Append("-f ");
						aLegacyCommand.Append(aLine);
						aLegacyCommand.Append(" ");

						aTestJob.Append("<a:string>");
						aTestJob.Append(aLine);
						aTestJob.AppendLine("</a:string>");

						aCounter++;
					}
			}

			aDebugCommand.Append("-threads 6");

			string aDebugOut = aDebugCommand.ToString().Trim();
			string aLegacyOut = aLegacyCommand.ToString().Trim();
			string aTestJobOut = aTestJob.ToString();
		} // <-- Place a breakpoint here and copy the values from the above strings that you need.
	}
}
