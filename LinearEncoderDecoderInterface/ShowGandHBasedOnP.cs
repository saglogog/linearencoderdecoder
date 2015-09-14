using System;
using LinearEncoderDecoderLibrary;


namespace LinearEncoderDecoderInterface
{

	//delegate for the event 
	public delegate void ErrorWindowEventHandler(object sender, ErrorWindowEventArgs e);  

	public class ErrorWindowEventArgs: EventArgs{
		public readonly string _labelMessage;

		public ErrorWindowEventArgs(string labelMessage){
			_labelMessage = labelMessage;
		}

	}

	public class ShowGandHBasedOnP
	{
		public event ErrorWindowEventHandler ErrorOccured;

		public string GenerateG(string p){
			
			this.ErrorOccured += new ErrorWindowEventHandler(CreateErrorWindow);

			char[] ca = p.ToCharArray ();
			char[] ca2;

			if (ca [ca.Length - 1] != '\n') {
				ca2 = new char[ca.Length + 1];
				ca.CopyTo (ca2, 0);
				ca2 [ca2.Length - 1] = '\n';
			} else {
				ca2 = new char[ca.Length];
				ca.CopyTo (ca2, 0);
			}
			
			int[,] P;

			int j = 0;
			int h = -1;
			ErrorWindowEventArgs ewea = null;
			for (int i = 0; i < ca2.Length; i++) {
				if (ca2 [i] != '\n')
					j++;
				else {
					if (h != -1 && h != j && ewea == null) {
						//show window with error explaining that this array doesnt have the correct format. 
						ewea = new ErrorWindowEventArgs ("The P Array does not have the correct format!");
						ErrorOccured (this, ewea);
					}
					h = j;
					j = 0;
				}
			}
				

			string ca3 = new string(ca2);

			return ca3;
		}

		public void CreateErrorWindow(object sender, ErrorWindowEventArgs e){
			//add label message from eventargs property
			ErrorWindow ew = new ErrorWindow (e._labelMessage);
			ew.Show ();
		}

		public int[,] ConvertCharArrayTo2DIntArray(char[] charArray, char delimiter){
			int rowCounter = 0;
			//count how many rows
			while (charArray [rowCounter] != delimiter) {
				rowCounter++;
			}

			//count how many lines taking into account the delimiter
			int lines = charArray.Length/(rowCounter+1);

			int[,] TwoDimArray = new int[lines, rowCounter];

			return TwoDimArray;
		}
	}
}