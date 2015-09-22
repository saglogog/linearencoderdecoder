using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;
using System.Threading;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class EncoderTests
	{


		[Test ()]
		public void TestEncodeAndCodewordCreator()
		{
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			//--PropertyClass pc = new PropertyClass ();
			//--int[,] PMatrix = pc.PArray;
			int[,] PMatrix = PropertyClass.PArray;
			Random rd = new Random ();
			int[] theWord = new int[PropertyClass.PArray.GetLength(0)];
			for (int i = 0; i < PropertyClass.PArray.GetLength (0); i++) {
				theWord [i] = rd.Next () % 2;
			}
			Encoder enc = new Encoder();
			int[] extraBits = enc.Encode (theWord);
			int[] codeword = enc.CodewordCreator (theWord);
			for (int i = 0; i < PMatrix.GetLength (0); i++) {
				for (int j = 0; j < PMatrix.GetLength (1); j++) {
					Console.Write(PMatrix[i,j]);
						if(j==PMatrix.GetLength(1)-1){
							Console.Write("\n");
						}
				}
			}
			Console.WriteLine ("Death to The Heathens");
			for (int i = 0; i < PMatrix.GetLength (1); i++) {
				 Console.Write (extraBits [i]);
			}
			Console.Write ("\n");


			Console.WriteLine("Here comes the codeword!!!");
			for (int i = 0; i < PMatrix.GetLength (1)+PMatrix.GetLength(0); i++) {
				Console.Write (codeword[i]);
			}
			Console.Write ("\n");
		}
	}
}

