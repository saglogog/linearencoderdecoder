﻿using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class EncoderTests
	{
		[Test()]
		public void TestMockSetup()
		{
			MockSetupClass msc = new MockSetupClass ();
			msc.FillMatrix ();
			//--PropertyClass pc = new PropertyClass ();
			//--int[,] pArray = pc.PArray;
			int[,] pArray = PropertyClass.PArray;
			for (int i = 0; i < pArray.GetLength (0); i++) {
				for (int j = 0; j < pArray.GetLength (1); j++) {
					Console.Write (pArray [i, j]);
					if (j == pArray.GetLength (1) - 1) {
						Console.Write ("\n");
					}
				}
			}

		}
		[Test ()]
		public void TestEncodeAndCodewordCreator()
		{
			MockSetupClass msc = new MockSetupClass ();
			msc.FillMatrix ();
			//--PropertyClass pc = new PropertyClass ();
			//--int[,] PMatrix = pc.PArray;
			int[,] PMatrix = PropertyClass.PArray;
			int[] theWord = {0,1,1};
			Encoder enc = new Encoder(theWord);
			int[] extraBits = enc.Encode ();
			int[] codeword = enc.CodewordCreator ();
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

