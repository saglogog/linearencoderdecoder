using System;
using LinearEncoderDecoderLibrary;

namespace LinearEncoderDecoderInterface
{
	public class ShowCodewordsBasedOnP
	{
		
		public int[,] GenerateCodewords(string p){

			int[,] thePArray = null;
			ShowGandHBasedOnP s = new ShowGandHBasedOnP ();
			if (PropertyClass.PArray != null) {
				thePArray = PropertyClass.PArray;
			} else {
				thePArray = s.ReturnPArray (p);
			}

			CodewordGenerator cs = new CodewordGenerator(thePArray.GetLength(0));


			return cs.CreateAllCodewordsBasedOnKAndP (thePArray.GetLength (0) + thePArray.GetLength (1));
		}

	}
}