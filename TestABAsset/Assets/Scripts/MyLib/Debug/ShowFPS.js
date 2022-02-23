#pragma strict

// Use this for initialization
private var rect : Rect;
private var fontSize : int = 20;
function Start () {
	var ratioH : float = (Camera.main.pixelWidth / 480.0);
	fontSize = fontSize * ratioH;
	rect.x = 0;
	rect.width = 100 * ratioH;
	rect.height = 50 * ratioH;
	rect.y = Camera.main.pixelHeight - fontSize * 1.5;
	//Application.targetFrameRate = 30;
}

// Update is called once per frame
function Update () {
	UpdateTick();
}

function OnGUI()
{
	DrawFps();
}

private function DrawFps()
{
	if (mLastFps > 50)
	{
		GUI.color = Color.green;
	}
	else if (mLastFps > 40)
	{
		GUI.color = Color.yellow;
	}
	else
	{
		GUI.color = Color.red;
	}
	GUI.Label(rect, "<size="+fontSize.ToString()+">fps: " + mLastFps + "</size>");

}

private var mFrameCount : long = 0;
private var mLastFrameTime : long = 0;
static var mLastFps : long= 0;

private function UpdateTick()
{
	if (true)
	{
		mFrameCount++;
		var nCurTime : long = TickToMilliSec(System.DateTime.Now.Ticks);
		if (mLastFrameTime == 0)
		{
			mLastFrameTime = TickToMilliSec(System.DateTime.Now.Ticks);
		}

		if ((nCurTime - mLastFrameTime) >= 1000)
		{
			var fps : long = (mFrameCount * 1.0f / ((nCurTime - mLastFrameTime) / 1000.0f));

			mLastFps = fps;

			mFrameCount = 0;

			mLastFrameTime = nCurTime;
		}
	}
}

static function TickToMilliSec(tick : long)
{
	return tick / (10 * 1000);
}



