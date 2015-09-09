using System;
using Gtk;

namespace LinearEncoderDecoderInterface
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{
			ShowGandHBasedOnP s = new ShowGandHBasedOnP ();
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			s.ErrorOccured += CreateErrorWindow;
		}

		public  void CreateErrorWindow(){
					ErrorWindow ew = new ErrorWindow ();
					ew.Show ();
				}
	}
}
