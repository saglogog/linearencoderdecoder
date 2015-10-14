using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;
using System.Linq;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class SyndromeAndCosetLeadersTests
	{
		[Test ()]
		public void TestReturnNumberOfOnesInBinary ()
		{
			Random rd = new Random ();

			int dec1 = rd.Next ();
			HelperClass hc = new HelperClass ();
			int[] bin1 = hc.CreateBinaryFromDecimal (dec1);

			MockSetupClass msc = new MockSetupClass ();
			SyndromesAndCosetLeaders scl = new SyndromesAndCosetLeaders (msc.ProvideCodewords ());
			int numberOfOnes = scl.ReturnNumberOfOnesInBinary (bin1);

			var digits = from digit in bin1
			where digit == 1
			select digit;

			int counter = digits.Count ();

			Console.WriteLine ("Binary being tested:");
			for (int i = 0; i < bin1.Length; i++) {
				Console.Write (bin1 [i]);
			}
			Console.WriteLine ();

			Console.WriteLine ("Number of ones from Return number of ones:" + numberOfOnes + ".");
			Console.WriteLine ("Number of ones from Linq query:" + counter + ".");

			Assert.AreEqual (counter, numberOfOnes);
			Console.WriteLine ("All done!");
		}

		[Test()]
		public void TestCheckForOnesInRectangularArrayOfBinaries(){
			MockSetupClass msc = new MockSetupClass ();
			//codewords used as an array of random binaries
			int[,] binaries = msc.ProvideCodewords();

			Console.WriteLine("The array of binaries being tested:");
			for (int i = 0; i < binaries.GetLength (0); i++) {
				for (int j = 0; j < binaries.GetLength (1); j++) {
					Console.Write(binaries[i,j]);
				}
				Console.WriteLine();
			}



		}
	}
}

