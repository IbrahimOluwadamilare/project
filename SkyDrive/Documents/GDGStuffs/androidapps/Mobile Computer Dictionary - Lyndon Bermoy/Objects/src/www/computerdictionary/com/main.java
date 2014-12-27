package www.computerdictionary.com;

import anywheresoftware.b4a.B4AMenuItem;
import android.app.Activity;
import android.os.Bundle;
import anywheresoftware.b4a.BA;
import anywheresoftware.b4a.BALayout;
import anywheresoftware.b4a.B4AActivity;
import anywheresoftware.b4a.ObjectWrapper;
import anywheresoftware.b4a.objects.ActivityWrapper;
import java.lang.reflect.InvocationTargetException;
import anywheresoftware.b4a.B4AUncaughtException;
import anywheresoftware.b4a.debug.*;
import java.lang.ref.WeakReference;

public class main extends Activity implements B4AActivity{
	public static main mostCurrent;
	static boolean afterFirstLayout;
	static boolean isFirst = true;
    private static boolean processGlobalsRun = false;
	BALayout layout;
	public static BA processBA;
	BA activityBA;
    ActivityWrapper _activity;
    java.util.ArrayList<B4AMenuItem> menuItems;
	private static final boolean fullScreen = false;
	private static final boolean includeTitle = true;
    public static WeakReference<Activity> previousOne;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		if (isFirst) {
			processBA = new BA(this.getApplicationContext(), null, null, "www.computerdictionary.com", "www.computerdictionary.com.main");
			processBA.loadHtSubs(this.getClass());
	        float deviceScale = getApplicationContext().getResources().getDisplayMetrics().density;
	        BALayout.setDeviceScale(deviceScale);
		}
		else if (previousOne != null) {
			Activity p = previousOne.get();
			if (p != null && p != this) {
                anywheresoftware.b4a.keywords.Common.Log("Killing previous instance (main).");
				p.finish();
			}
		}
		if (!includeTitle) {
        	this.getWindow().requestFeature(android.view.Window.FEATURE_NO_TITLE);
        }
        if (fullScreen) {
        	getWindow().setFlags(android.view.WindowManager.LayoutParams.FLAG_FULLSCREEN,   
        			android.view.WindowManager.LayoutParams.FLAG_FULLSCREEN);
        }
		mostCurrent = this;
        processBA.sharedProcessBA.activityBA = null;
		layout = new BALayout(this);
		setContentView(layout);
		afterFirstLayout = false;
		BA.handler.postDelayed(new WaitForLayout(), 5);

	}
	private static class WaitForLayout implements Runnable {
		public void run() {
			if (afterFirstLayout)
				return;
			if (mostCurrent == null)
				return;
			if (mostCurrent.layout.getWidth() == 0) {
				BA.handler.postDelayed(this, 5);
				return;
			}
			mostCurrent.layout.getLayoutParams().height = mostCurrent.layout.getHeight();
			mostCurrent.layout.getLayoutParams().width = mostCurrent.layout.getWidth();
			afterFirstLayout = true;
			mostCurrent.afterFirstLayout();
		}
	}
	private void afterFirstLayout() {
        if (this != mostCurrent)
			return;
		activityBA = new BA(this, layout, processBA, "www.computerdictionary.com", "www.computerdictionary.com.main");
        processBA.sharedProcessBA.activityBA = new java.lang.ref.WeakReference<BA>(activityBA);
        anywheresoftware.b4a.objects.ViewWrapper.lastId = 0;
        _activity = new ActivityWrapper(activityBA, "activity");
        anywheresoftware.b4a.Msgbox.isDismissing = false;
        initializeProcessGlobals();		
        initializeGlobals();
        
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Create, isFirst = " + isFirst + " **");
        processBA.raiseEvent2(null, true, "activity_create", false, isFirst);
		isFirst = false;
		if (this != mostCurrent)
			return;
        processBA.setActivityPaused(false);
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Resume **");
        processBA.raiseEvent(null, "activity_resume");
        if (android.os.Build.VERSION.SDK_INT >= 11) {
			try {
				android.app.Activity.class.getMethod("invalidateOptionsMenu").invoke(this,(Object[]) null);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

	}
	public void addMenuItem(B4AMenuItem item) {
		if (menuItems == null)
			menuItems = new java.util.ArrayList<B4AMenuItem>();
		menuItems.add(item);
	}
	@Override
	public boolean onCreateOptionsMenu(android.view.Menu menu) {
		super.onCreateOptionsMenu(menu);
		if (menuItems == null)
			return false;
		for (B4AMenuItem bmi : menuItems) {
			android.view.MenuItem mi = menu.add(bmi.title);
			if (bmi.drawable != null)
				mi.setIcon(bmi.drawable);
            if (android.os.Build.VERSION.SDK_INT >= 11) {
				try {
                    if (bmi.addToBar) {
				        android.view.MenuItem.class.getMethod("setShowAsAction", int.class).invoke(mi, 1);
                    }
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			mi.setOnMenuItemClickListener(new B4AMenuItemsClickListener(bmi.eventName.toLowerCase(BA.cul)));
		}
		return true;
	}
	private class B4AMenuItemsClickListener implements android.view.MenuItem.OnMenuItemClickListener {
		private final String eventName;
		public B4AMenuItemsClickListener(String eventName) {
			this.eventName = eventName;
		}
		public boolean onMenuItemClick(android.view.MenuItem item) {
			processBA.raiseEvent(item.getTitle(), eventName + "_click");
			return true;
		}
	}
    public static Class<?> getObject() {
		return main.class;
	}
    private Boolean onKeySubExist = null;
    private Boolean onKeyUpSubExist = null;
	@Override
	public boolean onKeyDown(int keyCode, android.view.KeyEvent event) {
		if (onKeySubExist == null)
			onKeySubExist = processBA.subExists("activity_keypress");
		if (onKeySubExist) {
			Boolean res =  (Boolean)processBA.raiseEvent2(_activity, false, "activity_keypress", false, keyCode);
			if (res == null || res == true)
				return true;
            else if (keyCode == anywheresoftware.b4a.keywords.constants.KeyCodes.KEYCODE_BACK) {
				finish();
				return true;
			}
		}
		return super.onKeyDown(keyCode, event);
	}
    @Override
	public boolean onKeyUp(int keyCode, android.view.KeyEvent event) {
		if (onKeyUpSubExist == null)
			onKeyUpSubExist = processBA.subExists("activity_keyup");
		if (onKeyUpSubExist) {
			Boolean res =  (Boolean)processBA.raiseEvent2(_activity, false, "activity_keyup", false, keyCode);
			if (res == null || res == true)
				return true;
		}
		return super.onKeyUp(keyCode, event);
	}
	@Override
	public void onNewIntent(android.content.Intent intent) {
		this.setIntent(intent);
	}
    @Override 
	public void onPause() {
		super.onPause();
        if (_activity == null) //workaround for emulator bug (Issue 2423)
            return;
		anywheresoftware.b4a.Msgbox.dismiss(true);
        anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Pause, UserClosed = " + activityBA.activity.isFinishing() + " **");
        processBA.raiseEvent2(_activity, true, "activity_pause", false, activityBA.activity.isFinishing());		
        processBA.setActivityPaused(true);
        mostCurrent = null;
        if (!activityBA.activity.isFinishing())
			previousOne = new WeakReference<Activity>(this);
        anywheresoftware.b4a.Msgbox.isDismissing = false;
	}

	@Override
	public void onDestroy() {
        super.onDestroy();
		previousOne = null;
	}
    @Override 
	public void onResume() {
		super.onResume();
        mostCurrent = this;
        anywheresoftware.b4a.Msgbox.isDismissing = false;
        if (activityBA != null) { //will be null during activity create (which waits for AfterLayout).
        	ResumeMessage rm = new ResumeMessage(mostCurrent);
        	BA.handler.post(rm);
        }
	}
    private static class ResumeMessage implements Runnable {
    	private final WeakReference<Activity> activity;
    	public ResumeMessage(Activity activity) {
    		this.activity = new WeakReference<Activity>(activity);
    	}
		public void run() {
			if (mostCurrent == null || mostCurrent != activity.get())
				return;
			processBA.setActivityPaused(false);
            anywheresoftware.b4a.keywords.Common.Log("** Activity (main) Resume **");
		    processBA.raiseEvent(mostCurrent._activity, "activity_resume", (Object[])null);
		}
    }
	@Override
	protected void onActivityResult(int requestCode, int resultCode,
	      android.content.Intent data) {
		processBA.onActivityResult(requestCode, resultCode, data);
	}
	private static void initializeGlobals() {
		processBA.raiseEvent2(null, true, "globals", false, (Object[])null);
	}

public anywheresoftware.b4a.keywords.Common __c = null;
public static anywheresoftware.b4a.sql.SQL _sql1 = null;
public static anywheresoftware.b4a.sql.SQL.CursorWrapper _cursor1 = null;
public anywheresoftware.b4a.objects.AutoCompleteEditTextWrapper _auto1 = null;
public anywheresoftware.b4a.objects.LabelWrapper _lbl1 = null;
public giuseppe.salvi.icos.library.TTs _tts = null;
public anywheresoftware.b4a.objects.ButtonWrapper _button1 = null;
public anywheresoftware.b4a.objects.LabelWrapper _label2 = null;
public flm.b4a.scrollview2d.ScrollView2DWrapper _sv2d = null;
public anywheresoftware.b4a.objects.StringUtils _strutil = null;
public www.computerdictionary.com.customlistview _clv1 = null;
public anywheresoftware.b4a.objects.PanelWrapper _panel1 = null;
public anywheresoftware.b4a.objects.ButtonWrapper _btnsearch = null;
public anywheresoftware.b4a.objects.ButtonWrapper _btnexit = null;
public static String  _activity_create(boolean _firsttime) throws Exception{
 //BA.debugLineNum = 42;BA.debugLine="Sub Activity_Create(FirstTime As Boolean)";
 //BA.debugLineNum = 44;BA.debugLine="Activity.LoadLayout(\"tutorial\")";
mostCurrent._activity.LoadLayout("tutorial",mostCurrent.activityBA);
 //BA.debugLineNum = 46;BA.debugLine="tts.InitializeTTs(\"tts\", \"en\")";
mostCurrent._tts.InitializeTTs(mostCurrent.activityBA,"tts","en");
 //BA.debugLineNum = 56;BA.debugLine="clv1.Initialize(Me, \"clv1\")";
mostCurrent._clv1._initialize(mostCurrent.activityBA,main.getObject(),"clv1");
 //BA.debugLineNum = 57;BA.debugLine="Panel1.AddView(clv1.AsView, 0, 0, Panel1.Width, Panel1.Height)";
mostCurrent._panel1.AddView((android.view.View)(mostCurrent._clv1._asview().getObject()),(int)(0),(int)(0),mostCurrent._panel1.getWidth(),mostCurrent._panel1.getHeight());
 //BA.debugLineNum = 59;BA.debugLine="clv1.DefaultTextBackgroundColor = Colors.DarkGray";
mostCurrent._clv1._defaulttextbackgroundcolor = anywheresoftware.b4a.keywords.Common.Colors.DarkGray;
 //BA.debugLineNum = 60;BA.debugLine="If File.Exists(File.DirInternal,\"db2.sqlite\") = False Then";
if (anywheresoftware.b4a.keywords.Common.File.Exists(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db2.sqlite")==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 61;BA.debugLine="File.Copy(File.DirAssets,\"db2.sqlite\",File.DirInternal,\"db2.sqlite\")";
anywheresoftware.b4a.keywords.Common.File.Copy(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"db2.sqlite",anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db2.sqlite");
 };
 //BA.debugLineNum = 64;BA.debugLine="If sql1.IsInitialized = False Then";
if (_sql1.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 65;BA.debugLine="sql1.Initialize(File.DirInternal, \"db2.sqlite\", False)";
_sql1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db2.sqlite",anywheresoftware.b4a.keywords.Common.False);
 };
 //BA.debugLineNum = 67;BA.debugLine="view1(\"\")";
_view1("");
 //BA.debugLineNum = 68;BA.debugLine="lbl1.Text = \"\"";
mostCurrent._lbl1.setText((Object)(""));
 //BA.debugLineNum = 74;BA.debugLine="End Sub";
return "";
}
public static String  _activity_pause(boolean _userclosed) throws Exception{
 //BA.debugLineNum = 89;BA.debugLine="Sub Activity_Pause (UserClosed As Boolean)";
 //BA.debugLineNum = 91;BA.debugLine="End Sub";
return "";
}
public static String  _activity_resume() throws Exception{
 //BA.debugLineNum = 77;BA.debugLine="Sub Activity_Resume";
 //BA.debugLineNum = 78;BA.debugLine="If File.Exists(File.DirInternal,\"db1.sqlite\") = False Then";
if (anywheresoftware.b4a.keywords.Common.File.Exists(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db1.sqlite")==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 79;BA.debugLine="File.Copy(File.DirAssets,\"db1.sqlite\",File.DirInternal,\"db1.sqlite\")";
anywheresoftware.b4a.keywords.Common.File.Copy(anywheresoftware.b4a.keywords.Common.File.getDirAssets(),"db1.sqlite",anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db1.sqlite");
 };
 //BA.debugLineNum = 82;BA.debugLine="If sql1.IsInitialized = False Then";
if (_sql1.IsInitialized()==anywheresoftware.b4a.keywords.Common.False) { 
 //BA.debugLineNum = 83;BA.debugLine="sql1.Initialize(File.DirInternal, \"db1.sqlite\", False)";
_sql1.Initialize(anywheresoftware.b4a.keywords.Common.File.getDirInternal(),"db1.sqlite",anywheresoftware.b4a.keywords.Common.False);
 };
 //BA.debugLineNum = 85;BA.debugLine="lbl1.Text = \"\"";
mostCurrent._lbl1.setText((Object)(""));
 //BA.debugLineNum = 87;BA.debugLine="End Sub";
return "";
}
public static String  _auto1_textchanged(String _old,String _new) throws Exception{
byte[] _buffer = null;
anywheresoftware.b4a.objects.streams.File.InputStreamWrapper _inputstream1 = null;
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _bitmap1 = null;
 //BA.debugLineNum = 93;BA.debugLine="Sub auto1_TextChanged (Old As String, New As String)";
 //BA.debugLineNum = 94;BA.debugLine="Dim buffer() As Byte";
_buffer = new byte[(int)(0)];
;
 //BA.debugLineNum = 95;BA.debugLine="Dim InputStream1 As InputStream";
_inputstream1 = new anywheresoftware.b4a.objects.streams.File.InputStreamWrapper();
 //BA.debugLineNum = 96;BA.debugLine="Dim Bitmap1 As Bitmap";
_bitmap1 = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 98;BA.debugLine="view1(auto1.Text)";
_view1(mostCurrent._auto1.getText());
 //BA.debugLineNum = 101;BA.debugLine="End Sub";
return "";
}
public static String  _btnexit_click() throws Exception{
 //BA.debugLineNum = 171;BA.debugLine="Sub btnExit_Click";
 //BA.debugLineNum = 172;BA.debugLine="Activity.Finish";
mostCurrent._activity.Finish();
 //BA.debugLineNum = 173;BA.debugLine="End Sub";
return "";
}
public static String  _btnsearch_click() throws Exception{
 //BA.debugLineNum = 152;BA.debugLine="Sub btnSearch_Click";
 //BA.debugLineNum = 153;BA.debugLine="view1(auto1.Text)";
_view1(mostCurrent._auto1.getText());
 //BA.debugLineNum = 155;BA.debugLine="If auto1.Text = cursor1.GetString(\"CName\") Then";
if ((mostCurrent._auto1.getText()).equals(_cursor1.GetString("CName"))) { 
 //BA.debugLineNum = 160;BA.debugLine="Msgbox(cursor1.GetString(\"Description\"),cursor1.GetString(\"CName\"))";
anywheresoftware.b4a.keywords.Common.Msgbox(_cursor1.GetString("Description"),_cursor1.GetString("CName"),mostCurrent.activityBA);
 }else {
 //BA.debugLineNum = 168;BA.debugLine="Msgbox(\"Word not found.\",\"Note\")";
anywheresoftware.b4a.keywords.Common.Msgbox("Word not found.","Note",mostCurrent.activityBA);
 };
 //BA.debugLineNum = 170;BA.debugLine="End Sub";
return "";
}
public static String  _button1_click() throws Exception{
int _i = 0;
 //BA.debugLineNum = 102;BA.debugLine="Sub Button1_Click";
 //BA.debugLineNum = 103;BA.debugLine="view1(auto1.Text)";
_view1(mostCurrent._auto1.getText());
 //BA.debugLineNum = 104;BA.debugLine="For i = 0 To cursor1.RowCount - 1";
{
final double step51 = 1;
final double limit51 = (int)(_cursor1.getRowCount()-1);
for (_i = (int)(0); (step51 > 0 && _i <= limit51) || (step51 < 0 && _i >= limit51); _i += step51) {
 //BA.debugLineNum = 105;BA.debugLine="cursor1.Position = i";
_cursor1.setPosition(_i);
 //BA.debugLineNum = 106;BA.debugLine="If auto1.Text <> cursor1.GetString(\"CName\") Then";
if ((mostCurrent._auto1.getText()).equals(_cursor1.GetString("CName")) == false) { 
 //BA.debugLineNum = 107;BA.debugLine="Msgbox(\"Word is not in the dictionary.\",\"Note\")";
anywheresoftware.b4a.keywords.Common.Msgbox("Word is not in the dictionary.","Note",mostCurrent.activityBA);
 }else {
 //BA.debugLineNum = 109;BA.debugLine="tts.Speaking(auto1.Text)";
mostCurrent._tts.Speaking(mostCurrent.activityBA,mostCurrent._auto1.getText());
 };
 }
};
 //BA.debugLineNum = 112;BA.debugLine="End Sub";
return "";
}
public static String  _clv1_itemclick(int _index,Object _value) throws Exception{
 //BA.debugLineNum = 138;BA.debugLine="Sub clv1_ItemClick (Index As Int, Value As Object)";
 //BA.debugLineNum = 150;BA.debugLine="Msgbox(Value,\"\")";
anywheresoftware.b4a.keywords.Common.Msgbox(String.valueOf(_value),"",mostCurrent.activityBA);
 //BA.debugLineNum = 151;BA.debugLine="End Sub";
return "";
}

public static void initializeProcessGlobals() {
    
    if (processGlobalsRun == false) {
	    processGlobalsRun = true;
		try {
		        main._process_globals();
		
        } catch (Exception e) {
			throw new RuntimeException(e);
		}
    }
}

public static boolean isAnyActivityVisible() {
    boolean vis = false;
vis = vis | (main.mostCurrent != null);
return vis;}
public static String  _globals() throws Exception{
 //BA.debugLineNum = 22;BA.debugLine="Sub Globals";
 //BA.debugLineNum = 25;BA.debugLine="Dim auto1 As AutoCompleteEditText";
mostCurrent._auto1 = new anywheresoftware.b4a.objects.AutoCompleteEditTextWrapper();
 //BA.debugLineNum = 26;BA.debugLine="Dim lbl1 As Label";
mostCurrent._lbl1 = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 27;BA.debugLine="Dim tts As ICOSTextToSpeech";
mostCurrent._tts = new giuseppe.salvi.icos.library.TTs();
 //BA.debugLineNum = 30;BA.debugLine="Dim Button1 As Button";
mostCurrent._button1 = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 33;BA.debugLine="Dim Label2 As Label";
mostCurrent._label2 = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 34;BA.debugLine="Dim sv2d As ScrollView2D";
mostCurrent._sv2d = new flm.b4a.scrollview2d.ScrollView2DWrapper();
 //BA.debugLineNum = 35;BA.debugLine="Dim StrUtil As StringUtils";
mostCurrent._strutil = new anywheresoftware.b4a.objects.StringUtils();
 //BA.debugLineNum = 36;BA.debugLine="Dim clv1 As CustomListView";
mostCurrent._clv1 = new www.computerdictionary.com.customlistview();
 //BA.debugLineNum = 37;BA.debugLine="Dim Panel1 As Panel";
mostCurrent._panel1 = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 38;BA.debugLine="Dim btnSearch As Button";
mostCurrent._btnsearch = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 39;BA.debugLine="Dim btnExit As Button";
mostCurrent._btnexit = new anywheresoftware.b4a.objects.ButtonWrapper();
 //BA.debugLineNum = 40;BA.debugLine="End Sub";
return "";
}
public static String  _process_globals() throws Exception{
 //BA.debugLineNum = 15;BA.debugLine="Sub Process_Globals";
 //BA.debugLineNum = 18;BA.debugLine="Dim sql1 As SQL";
_sql1 = new anywheresoftware.b4a.sql.SQL();
 //BA.debugLineNum = 19;BA.debugLine="Dim cursor1 As Cursor";
_cursor1 = new anywheresoftware.b4a.sql.SQL.CursorWrapper();
 //BA.debugLineNum = 20;BA.debugLine="End Sub";
return "";
}
public static String  _view1(String _psearch) throws Exception{
String _demotext = "";
int _i = 0;
String[] _nomi = null;
anywheresoftware.b4a.objects.LabelWrapper _str = null;
anywheresoftware.b4a.objects.LabelWrapper _lbl = null;
 //BA.debugLineNum = 114;BA.debugLine="Sub view1( psearch As String)";
 //BA.debugLineNum = 116;BA.debugLine="Dim DemoText As String";
_demotext = "";
 //BA.debugLineNum = 118;BA.debugLine="cursor1 = sql1.ExecQuery(\"Select * from tbDictionary WHERE CName like '\" & psearch & \"%'\")";
_cursor1.setObject((android.database.Cursor)(_sql1.ExecQuery("Select * from tbDictionary WHERE CName like '"+_psearch+"%'")));
 //BA.debugLineNum = 119;BA.debugLine="For i = 0 To cursor1.RowCount - 1";
{
final double step63 = 1;
final double limit63 = (int)(_cursor1.getRowCount()-1);
for (_i = (int)(0); (step63 > 0 && _i <= limit63) || (step63 < 0 && _i >= limit63); _i += step63) {
 //BA.debugLineNum = 120;BA.debugLine="cursor1.Position = i";
_cursor1.setPosition(_i);
 //BA.debugLineNum = 121;BA.debugLine="Dim nomi() As String";
_nomi = new String[(int)(0)];
java.util.Arrays.fill(_nomi,"");
 //BA.debugLineNum = 122;BA.debugLine="Dim str As Label";
_str = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 123;BA.debugLine="nomi = Array As String(cursor1.GetString(\"CName\"))";
_nomi = new String[]{_cursor1.GetString("CName")};
 //BA.debugLineNum = 124;BA.debugLine="auto1.SetItems(nomi)";
mostCurrent._auto1.SetItems(processBA,anywheresoftware.b4a.keywords.Common.ArrayToList(_nomi));
 //BA.debugLineNum = 125;BA.debugLine="Dim lbl As Label";
_lbl = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 126;BA.debugLine="lbl.Initialize(\"lbl\")";
_lbl.Initialize(mostCurrent.activityBA,"lbl");
 //BA.debugLineNum = 127;BA.debugLine="lbl.Gravity = Bit.OR(Gravity.CENTER_VERTICAL, Gravity.TOP)";
_lbl.setGravity(anywheresoftware.b4a.keywords.Common.Bit.Or(anywheresoftware.b4a.keywords.Common.Gravity.CENTER_VERTICAL,anywheresoftware.b4a.keywords.Common.Gravity.TOP));
 //BA.debugLineNum = 128;BA.debugLine="lbl.Text = cursor1.GetString(\"CName\")";
_lbl.setText((Object)(_cursor1.GetString("CName")));
 //BA.debugLineNum = 129;BA.debugLine="lbl.TextSize = 16";
_lbl.setTextSize((float)(16));
 //BA.debugLineNum = 130;BA.debugLine="lbl.TextColor = Colors.Red";
_lbl.setTextColor(anywheresoftware.b4a.keywords.Common.Colors.Red);
 //BA.debugLineNum = 133;BA.debugLine="clv1.AddTextItem(lbl.Text & CRLF & \"\",cursor1.GetString(\"Description\"))";
mostCurrent._clv1._addtextitem(_lbl.getText()+anywheresoftware.b4a.keywords.Common.CRLF+"",(Object)(_cursor1.GetString("Description")));
 }
};
 //BA.debugLineNum = 136;BA.debugLine="End Sub";
return "";
}
}
