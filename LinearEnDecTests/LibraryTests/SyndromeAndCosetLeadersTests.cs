using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;
using System.Linq;
using System.Collections.Generic;

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

			SyndromesAndCosetLeaders scl = new SyndromesAndCosetLeaders (binaries);
			int[] onesArray = scl.CheckForOnesInRectangularArrayOfBinaries (binaries);

			Console.WriteLine ("The array that count the ones in every row of the binaries being tested:");
			for (int j = 0; j < onesArray.GetLength (0); j++) {
				Console.Write(onesArray[j]+" ");
			}
			Console.WriteLine();
		}

		[Test()]
		public void TestCheckIfCosetExists(){
			List<int[]> cosetsAlreadyUsed = new List<int[]> ();
			MockSetupClass msc = new MockSetupClass ();
			Random rd = new Random ();

			int[,] binaries = msc.ProvideCodewords ();
			int randomRow = rd.Next (binaries.GetLength (0)-1);
			int[] binaryToTest1 = new int[binaries.GetLength (1)]; 
			int[] binaryToTest2 = new int[binaries.GetLength (1)]; 

			int[] currentBinary = new int[binaries.GetLength (1)];
			for (int i = 0; i < binaries.GetLength (0); i++) {
				for (int j = 0; j < binaries.GetLength (1); j++) {
					currentBinary [j] = binaries [i, j];
				}
				cosetsAlreadyUsed.Add (currentBinary);
			}

			//get a binary that exists in the binaries array
			for (int i = 0; i < binaries.GetLength (1); i++) {
				binaryToTest1 [i] = binaries [randomRow, i];
			}
			//get a binary that probably doesnt exist in the binaries array
			for (int i = 0; i < binaries.GetLength (1); i++) {
				binaryToTest2 [i] = rd.Next () % 2;
			}


			SyndromesAndCosetLeaders scl = new SyndromesAndCosetLeaders (binaries);


		}

		[Test()]
		public void TestAddBinariesMod2(){
			Random rd = new Random ();
			int binaryLength = rd.Next (1, 10);

			int[] binary1 = new int[binaryLength];
			int[] binary2 = new int[binaryLength];

			//populate binary1
			for (int i = 0; i < binaryLength; i++) {
				binary1 [i] = rd.Next () % 2;
			}

			//populate binary2
			for (int i = 0; i < binaryLength; i++) {
				binary2 [i] = rd.Next () % 2;
			}

			MockSetupClass msc = new MockSetupClass ();
			SyndromesAndCosetLeaders scl = new SyndromesAndCosetLeaders (msc.ProvideCodewords ());
			int[] binaryResult = scl.addBinariesMod2 (binary1, binary2);


			Console.WriteLine ("Binary1:");
			for (int j = 0; j < binaryLength; j++) {
				Console.Write(binary1[j]+" ");
			}
			Console.WriteLine ();

			Console.WriteLine ("Binary2:");
			for (int j = 0; j < binaryLength; j++) {
				Console.Write(binary2[j]+" ");
			}
			Console.WriteLine ();

			Console.WriteLine ("Mod2 Addition Result:");
			for (int j = 0; j < binaryLength; j++) {
				Console.Write(binaryResult[j]+" ");
			}
			Console.WriteLine ();
		}


		[Test()]
		public void TestGetARowOfCosets(){
			//getARowOfCosets() essentially adds a binary with mod2 addition to each binary of a row of binaries and 
			//returns an array of the results

			MockSetupClass msc = new MockSetupClass ();
			int[,] codewordsArray = msc.ProvideCodewords ();
			SyndromesAndCosetLeaders scl = new SyndromesAndCosetLeaders (codewordsArray);

			int[] randomBinary = msc.GetARandomBinary (codewordsArray.GetLength (1));

			int[][] cosetsRow = scl.GetARowOfCosets (randomBinary);


			Console.WriteLine ("Trying to get a row of a standard array, the first of the two rows are the codewords:");

			for (int i = 0; i < codewordsArray.GetLength (0); i++) {
				for (int j = 0; j < codewordsArray.GetLength (1); j++) {
					Console.Write(codewordsArray[i,j]);
				}
				Console.Write("  ");
			}

			Console.WriteLine ();

			for (int i = 0; i < cosetsRow.Length; i++) {
				for (int j = 0; j < cosetsRow [i].Length; j++) {
					Console.Write (cosetsRow[i][j]);
				}
				Console.Write ("  ");
			}
		}


	}
}