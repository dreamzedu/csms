using System;
using System.Runtime.InteropServices;	// for PlaySound()
using Microsoft.Win32;
namespace SMS
{
	/// <summary>
	/// Summary description for Sound.
	/// </summary>
	public class Sound
	{
			[DllImport("winmm.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
		static extern bool PlaySound( string pszSound,
		 IntPtr hMod, SoundFlags sf );

		[Flags]
			public enum SoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */
			SND_ASYNC = 0x0001,  /* play asynchronously */
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}

		public Sound()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Play(string filename)
		 {
			 int err = 0;	// last error

			 try
			 {
				 // play the sound from the selected filename
				 if (!PlaySound( filename, IntPtr.Zero,
					 SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC ))
				 {
				 }
					 //MessageBox.Show(this,
						 //"Unable to find specified sound file or default Windows sound");
			 }
			 catch
			 {
				 err = Marshal.GetLastWin32Error();
				 if (err != 0)
				 {
				 }
					// MessageBox.Show( this,
						// "Error " + err.ToString(),
						// "PlaySound() failed",
						// MessageBoxButtons.OK,
						// MessageBoxIcon.Error );
			 }
		 }
	}
}
