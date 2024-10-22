﻿using System;
using System.Threading;

namespace LinearEncoderDecoderLibrary
{
	public class Encoder
	{
		int[,] P;
		public Encoder ()
		{
			P = PropertyClass.PArray;
		}

		public int[] Encode(int[] word){
			//the  CHECK DIGITS of EACH codeword isountai me n-k:
			//kanoume ginomeno mitrwn metaxu tou 
			//msg_part_digit(=d) x P = (d1xp11 + d2xp12 + ... + dkxp1k, d1xp21 + d2xp22 + ... + dkxp2k, ..., d1xpk1 + d2xpk2 + ... +dkxpk(n-k))
			int[] extraDigits = new int[P.GetLength (1)];
			for (int i = 0; i < P.GetLength (1); i++) {
				for (int j = 0; j < P.GetLength (0); j++) {
					extraDigits [i] += word [j] * P [j, i];
				}
				extraDigits [i] = extraDigits [i] % 2;
			}
			return extraDigits;
		}

		//paratirontas oti ta prwta k psifia tis kwd. lexis einai idia me ta psifia tou tmimatos tou minimatos (edw word) aplws
		//"kollame" ta k psifia tis lexis prin ta n-k psifia ta opoia exoun pol/stei me ton p
		public int[] CodewordCreator(int[] word){
			int[] extraDigits = Encode (word);
			int[] codeword = new int[word.Length + extraDigits.Length];
			for (int i = 0; i < word.Length; i++) {
				codeword [i] = word [i];
			}
			for (int i = 0; i < extraDigits.Length; i++) {
				codeword [(word.Length) + i] = extraDigits [i];
			}
			return codeword;
		}
	}
}