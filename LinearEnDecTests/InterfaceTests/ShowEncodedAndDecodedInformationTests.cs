using System;
using NUnit.Framework;
using LinearEncoderDecoderLibrary;
using LinearEncoderDecoderInterface;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class ShowEncodedAndDecodedInformationTests
	{
		[Test ()]
		public void TestGetIntArrayFromString(){
			//Arrange
			Random rd = new Random();
			int[] intArrayExpected = new int[rd.Next(20)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			//Act
			HelperClass hc = new HelperClass();
			string data = hc.ConvertIntArrayToString (intArrayExpected);
			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();
			int[] intArrayActual = se.GetIntArrayFromString (data);

			//Assert
			for (int i = 0; i < intArrayExpected.Length; i++) {
				Assert.AreEqual (intArrayExpected [i], intArrayActual [i]);
			}
		}

		[Test ()]
		public void TestGenerateEncodedInfo(){
			//Arrange
			MockSetupClass msc = new MockSetupClass();
			if (PropertyClass.PArray == null) {
				msc.FillMatrix ();
			}
			Random rd = new Random();
			int[] intArrayExpected = new int[PropertyClass.PArray.GetLength(0)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			HelperClass hc = new HelperClass();
			string data = hc.ConvertIntArrayToString (intArrayExpected);
			//Act
			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();
			int[] encodedInfo = se.GenerateEncodedInfo (data);
			string encodedData = hc.ConvertIntArrayToString (encodedInfo);
			string pString = hc.Convert2DIntArrayToString (PropertyClass.PArray, '\n');
			//Assert
			Console.WriteLine("Data:\n" + data + '\n');
			Console.Write ("Encoded data: \n" + encodedData + '\n');
			Console.Write ("PArray:" + '\n' + pString);
		}

		[Test ()]
		public void TestGenerateDecodedInfo(){
			MockSetupClass msc = new MockSetupClass ();
			if (PropertyClass.PArray == null) {
				msc.FillMatrix ();
			}
			Random rd = new Random();
			int[] intArrayExpected = new int[PropertyClass.PArray.GetLength(0)+PropertyClass.PArray.GetLength(1)];
			for (int i = 0; i < intArrayExpected.Length; i++) {
				intArrayExpected [i] = rd.Next () % 2;
			}
			//string data = hc.ConvertIntArrayToString (intArrayExpected);
			MatrixCreator mc = new MatrixCreator();

			ShowEncodedAndDecodedInformation se = new ShowEncodedAndDecodedInformation ();
			int[][] errorSyndromes = se.GeneratedDecodedInfo ("000110", mc.HCreator ());
			for (int i = 0; i < PropertyClass.PArray.GetLength(1); i++) {
				for (int j = 0; j < PropertyClass.PArray.GetLength (0) + PropertyClass.PArray.GetLength (1); j++) {
					Console.Write (errorSyndromes [i][j]);
				}
				Console.WriteLine ("");
			}

		}
	}
}