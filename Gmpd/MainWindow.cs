using System;
using System.Net;
using Gtk;
using Libmpc;

public partial class MainWindow: Gtk.Window
{	
	private Mpc mpd = new Mpc();
	private MpcConnection connection = new MpcConnection();
	private byte[] server = {(byte) 127,(byte) 0,(byte) 0, (byte)1 };
	private int port = 6600;
	
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();	
		this.connection.OnConnected += HandleOnConnected;
		this.connection.OnDisconnected += HandleOnDisconnected;
		this.connection.AutoConnect = true;
	}

	protected void HandleOnDisconnected(MpcConnection connection)
	{
		Console.WriteLine("disconnected");
	}

	protected void HandleOnConnected(MpcConnection connection)
	{
		Console.WriteLine("connect " + connection.Connected);		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{		
		
	}

	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		
	}

	protected virtual void OnButton3Clicked (object sender, System.EventArgs e)
	{
		this.connection.Connect(new IPEndPoint(new IPAddress(this.server),this.port));
		if(this.connection.Connected)
		{		
			this.mpd.SetVol(100);
			this.mpd.Play();
		}
		this.connection.Disconnect();
		this.mpd.Stop();
	}

	protected virtual void OnButton4Clicked (object sender, System.EventArgs e)
	{
		
	}
}