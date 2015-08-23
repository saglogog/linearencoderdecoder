using System;
using NUnit.Framework;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class DecoderTests
	{
		[Test()]
		public void TestCorrectCodeword(){
			Decoder dec = new Decoder ();
			//65
			int[] erroneousCodeword = new int[]{ 1, 0, 0, 0, 0, 0, 1 };
			//60
			int[] errorVector = new int[]{ 1, 1, 1, 1, 0, 0 };

			int[] result = dec.CorrectCodeword (erroneousCodeword, errorVector);

			for (int i = 0; i < result.Length; i++) {
				Console.Write (result [i]);
			}
		}
	}
}

