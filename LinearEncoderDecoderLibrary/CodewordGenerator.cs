using System;

namespace LinearEncoderDecoderLibrary
{
	public class CodewordGenerator
	{
		int k;
		public CodewordGenerator (int givenNumber)
		{
			k = givenNumber;
		}
			
		/// <summary>
		/// Creates all possible binary message words with k digits, based on the k variable.
		/// Thus x^k, x=2. 
		/// i∈[0,2^k-1] in decimal. Thus, since we have k digits in each message word the
		/// only thing left to do einai i metatropi apo decimal se binary.
		/// Could also use lists and Descending Powers of Two and Subtraction method to calculate the 
		/// binary from decimal. May prove more efficient.
		/// </summary>
		/// <returns>The all message word(lol-the all message world).</returns>
		public int[,] CreateAllBinaryMsgWords(){
			//quotient
			int q;
			//remainder arrays, and our words 
			int[,] r = new int[(int)Math.Pow(2, k), k];
			try{
				for (int i = 0; i < Math.Pow (2, k); i++) {
					q=i;
					//use conversion from binary to decimal
					for (int j = 0; j < k; j++) {
						//r[k-j] gt ta i diairesi ginetai apo ton megalutero ston mikrotero arithmo enw
						//ta duadika psifia sumbolizontai antistrofa
						r[i, (k-1)-j]=q%2;
						//to dekadiko meros - decimal value left of the dot
						q = (int)Math.Truncate((double)q / 2);
					}
				}
			}
			catch(IndexOutOfRangeException e){
				Console.Write ("index out of range exception w/ stacktrace:\n");
				Console.Write (e.StackTrace);
			}
			return r;
		}

		public void CreateAllCodewordsBasedOnKAndP(){
			int[,] msgWords = CreateAllBinaryMsgWords ();
			//--PropertyClass pc = new PropertyClass ();
			//--pc.PArray;
			//Encoder enc = new Encoder();
			for (int i = 0; i < msgWords.GetLength (0); i++) {
				
			}
		}
	}
}