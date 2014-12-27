package www.computerdictionary.com;

import anywheresoftware.b4a.BA;
import anywheresoftware.b4a.B4AClass;
import anywheresoftware.b4a.BALayout;
import anywheresoftware.b4a.debug.*;

public class clsscrollpanel extends B4AClass.ImplB4AClass{
    private static java.util.HashMap<String, java.lang.reflect.Method> htSubs;
    private void innerInitialize(BA _ba) throws Exception {
        if (ba == null) {
            ba = new BA(_ba, this, htSubs, "www.computerdictionary.com.clsscrollpanel");
            if (htSubs == null) {
                ba.loadHtSubs(this.getClass());
                htSubs = ba.htSubs;
            }
        }
        _class_globals();
    }


 public static class _typcache{
public boolean IsInitialized;
public int Top;
public int Index;
public void Initialize() {
IsInitialized = true;
Top = 0;
Index = 0;
}
@Override
		public String toString() {
			return BA.TypeToString(this, false);
		}}
public anywheresoftware.b4a.keywords.Common __c = null;
public anywheresoftware.b4a.objects.ScrollViewWrapper _sv = null;
public anywheresoftware.b4a.objects.PanelWrapper _pnlrange = null;
public anywheresoftware.b4a.objects.PanelWrapper _pnldisplay = null;
public anywheresoftware.b4a.objects.LabelWrapper _lbldisplay = null;
public Object _callbackshowhide = null;
public Object _callbacktextupdated = null;
public String _showhidesubname = "";
public String _textupdatedsubname = "";
public anywheresoftware.b4a.objects.AnimationWrapper _anim = null;
public anywheresoftware.b4a.objects.Timer _timeout = null;
public int _duration = 0;
public int _minpos = 0;
public int _maxpos = 0;
public boolean _busermovingpnl = false;
public boolean _bwaitforscroll = false;
public boolean _busecache = false;
public anywheresoftware.b4a.objects.collections.List _cache = null;
public www.computerdictionary.com.main _main = null;
public String  _anim_animationend() throws Exception{
 //BA.debugLineNum = 311;BA.debugLine="Private Sub Anim_AnimationEnd";
 //BA.debugLineNum = 312;BA.debugLine="pnlRange.Visible = False";
_pnlrange.setVisible(__c.False);
 //BA.debugLineNum = 313;BA.debugLine="End Sub";
return "";
}
public String  _calcnewtop() throws Exception{
 //BA.debugLineNum = 269;BA.debugLine="Private Sub CalcNewTop";
 //BA.debugLineNum = 270;BA.debugLine="Return (sv.ScrollPosition / (sv.Panel.Height - getHeight) * MaxPos) + MinPos";
if (true) return BA.NumberToString((_sv.getScrollPosition()/(double)(_sv.getPanel().getHeight()-_getheight())*_maxpos)+_minpos);
 //BA.debugLineNum = 271;BA.debugLine="End Sub";
return "";
}
public String  _class_globals() throws Exception{
 //BA.debugLineNum = 3;BA.debugLine="Sub Class_Globals";
 //BA.debugLineNum = 4;BA.debugLine="Private sv As ScrollView";
_sv = new anywheresoftware.b4a.objects.ScrollViewWrapper();
 //BA.debugLineNum = 5;BA.debugLine="Private pnlRange As Panel";
_pnlrange = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 6;BA.debugLine="Private pnlDisplay As Panel";
_pnldisplay = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 7;BA.debugLine="Private lblDisplay As Label";
_lbldisplay = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 8;BA.debugLine="Private CallbackShowHide As Object";
_callbackshowhide = new Object();
 //BA.debugLineNum = 9;BA.debugLine="Private CallbackTextUpdated As Object";
_callbacktextupdated = new Object();
 //BA.debugLineNum = 10;BA.debugLine="Private ShowHideSubName As String";
_showhidesubname = "";
 //BA.debugLineNum = 11;BA.debugLine="Private TextUpdatedSubName As String";
_textupdatedsubname = "";
 //BA.debugLineNum = 12;BA.debugLine="Private Anim As Animation";
_anim = new anywheresoftware.b4a.objects.AnimationWrapper();
 //BA.debugLineNum = 13;BA.debugLine="Private TimeOut As Timer";
_timeout = new anywheresoftware.b4a.objects.Timer();
 //BA.debugLineNum = 14;BA.debugLine="Private Duration As Int: Duration = 400";
_duration = 0;
 //BA.debugLineNum = 14;BA.debugLine="Private Duration As Int: Duration = 400";
_duration = (int)(400);
 //BA.debugLineNum = 15;BA.debugLine="Private MinPos, MaxPos As Int";
_minpos = 0;
_maxpos = 0;
 //BA.debugLineNum = 16;BA.debugLine="Private bUserMovingPnl As Boolean";
_busermovingpnl = false;
 //BA.debugLineNum = 17;BA.debugLine="Private bWaitForScroll As Boolean";
_bwaitforscroll = false;
 //BA.debugLineNum = 18;BA.debugLine="Private bUseCache As Boolean";
_busecache = false;
 //BA.debugLineNum = 19;BA.debugLine="Private Cache As List";
_cache = new anywheresoftware.b4a.objects.collections.List();
 //BA.debugLineNum = 20;BA.debugLine="Type typCache(Top As Int, Index As Int)";
;
 //BA.debugLineNum = 21;BA.debugLine="End Sub";
return "";
}
public String  _displaycustomtext(int _position,String _text) throws Exception{
 //BA.debugLineNum = 262;BA.debugLine="Public Sub DisplayCustomText(Position As Int, Text As String)";
 //BA.debugLineNum = 263;BA.debugLine="If pnlDisplay.IsInitialized Then";
if (_pnldisplay.IsInitialized()) { 
 //BA.debugLineNum = 264;BA.debugLine="DisplayPnl(Position, Text)";
_displaypnl(_position,_text);
 };
 //BA.debugLineNum = 266;BA.debugLine="End Sub";
return "";
}
public String  _displayfirstchar(int _position) throws Exception{
String _toptext = "";
 //BA.debugLineNum = 233;BA.debugLine="Public Sub DisplayFirstChar(Position As Int)";
 //BA.debugLineNum = 234;BA.debugLine="If pnlDisplay.IsInitialized Then";
if (_pnldisplay.IsInitialized()) { 
 //BA.debugLineNum = 235;BA.debugLine="Dim TopText As String";
_toptext = "";
 //BA.debugLineNum = 236;BA.debugLine="TopText = GetTopText.Trim";
_toptext = _gettoptext().trim();
 //BA.debugLineNum = 237;BA.debugLine="If TopText <> \"\" Then TopText = TopText.CharAt(0)";
if ((_toptext).equals("") == false) { 
_toptext = String.valueOf(_toptext.charAt((int)(0)));};
 //BA.debugLineNum = 238;BA.debugLine="DisplayPnl(Position, TopText.ToUpperCase)";
_displaypnl(_position,_toptext.toUpperCase());
 };
 //BA.debugLineNum = 240;BA.debugLine="End Sub";
return "";
}
public String  _displaypnl(int _position,String _txt) throws Exception{
 //BA.debugLineNum = 273;BA.debugLine="Private Sub DisplayPnl(Position As Int, Txt As String)";
 //BA.debugLineNum = 274;BA.debugLine="lblDisplay.Text = Txt";
_lbldisplay.setText((Object)(_txt));
 //BA.debugLineNum = 275;BA.debugLine="RaiseTextUpdated(Txt)";
_raisetextupdated(_txt);
 //BA.debugLineNum = 277;BA.debugLine="If bWaitForScroll Then";
if (_bwaitforscroll) { 
 //BA.debugLineNum = 279;BA.debugLine="If pnlDisplay.Top = CalcNewTop Then";
if (_pnldisplay.getTop()==(double)(Double.parseDouble(_calcnewtop()))) { 
 //BA.debugLineNum = 280;BA.debugLine="Return";
if (true) return "";
 }else {
 //BA.debugLineNum = 282;BA.debugLine="bWaitForScroll = False";
_bwaitforscroll = __c.False;
 };
 };
 //BA.debugLineNum = 286;BA.debugLine="If sv.Panel.Height > getHeight Then";
if (_sv.getPanel().getHeight()>_getheight()) { 
 //BA.debugLineNum = 288;BA.debugLine="pnlRange.Visible = True";
_pnlrange.setVisible(__c.True);
 //BA.debugLineNum = 289;BA.debugLine="RaiseShowHide(True)";
_raiseshowhide(__c.True);
 };
 //BA.debugLineNum = 292;BA.debugLine="If Not(bUserMovingPnl) Then";
if (__c.Not(_busermovingpnl)) { 
 //BA.debugLineNum = 293;BA.debugLine="TimeOut.Enabled = False";
_timeout.setEnabled(__c.False);
 //BA.debugLineNum = 294;BA.debugLine="Anim.Stop(pnlDisplay)";
_anim.Stop((android.view.View)(_pnldisplay.getObject()));
 //BA.debugLineNum = 295;BA.debugLine="pnlDisplay.Top = CalcNewTop";
_pnldisplay.setTop((int)(Double.parseDouble(_calcnewtop())));
 //BA.debugLineNum = 296;BA.debugLine="If Position = sv.ScrollPosition Then";
if (_position==_sv.getScrollPosition()) { 
 //BA.debugLineNum = 298;BA.debugLine="TimeOut.Interval = Duration";
_timeout.setInterval((long)(_duration));
 //BA.debugLineNum = 299;BA.debugLine="TimeOut.Enabled = True";
_timeout.setEnabled(__c.True);
 //BA.debugLineNum = 300;BA.debugLine="bWaitForScroll = True";
_bwaitforscroll = __c.True;
 };
 };
 //BA.debugLineNum = 303;BA.debugLine="End Sub";
return "";
}
public String  _displaytag(int _position) throws Exception{
 //BA.debugLineNum = 255;BA.debugLine="Public Sub DisplayTag(Position As Int)";
 //BA.debugLineNum = 256;BA.debugLine="If pnlDisplay.IsInitialized Then";
if (_pnldisplay.IsInitialized()) { 
 //BA.debugLineNum = 257;BA.debugLine="DisplayPnl(Position, GetTopMostView(Position).Tag)";
_displaypnl(_position,String.valueOf(_gettopmostview(_position).getTag()));
 };
 //BA.debugLineNum = 259;BA.debugLine="End Sub";
return "";
}
public String  _displaytextline(int _position) throws Exception{
String _toptext = "";
int _poscrlf = 0;
 //BA.debugLineNum = 243;BA.debugLine="Public Sub DisplayTextLine(Position As Int)";
 //BA.debugLineNum = 244;BA.debugLine="If pnlDisplay.IsInitialized Then";
if (_pnldisplay.IsInitialized()) { 
 //BA.debugLineNum = 245;BA.debugLine="Dim TopText As String";
_toptext = "";
 //BA.debugLineNum = 246;BA.debugLine="TopText = GetTopText.Trim";
_toptext = _gettoptext().trim();
 //BA.debugLineNum = 247;BA.debugLine="Dim PosCRLF As Int";
_poscrlf = 0;
 //BA.debugLineNum = 248;BA.debugLine="PosCRLF = TopText.IndexOf(CRLF)";
_poscrlf = _toptext.indexOf(__c.CRLF);
 //BA.debugLineNum = 249;BA.debugLine="If PosCRLF > 0 Then TopText = TopText.SubString2(0, PosCRLF)";
if (_poscrlf>0) { 
_toptext = _toptext.substring((int)(0),_poscrlf);};
 //BA.debugLineNum = 250;BA.debugLine="DisplayPnl(Position, TopText)";
_displaypnl(_position,_toptext);
 };
 //BA.debugLineNum = 252;BA.debugLine="End Sub";
return "";
}
public int  _findincache(String _position,String _posprec,String _pos,int _posmax) throws Exception{
www.computerdictionary.com.clsscrollpanel._typcache _c = null;
www.computerdictionary.com.clsscrollpanel._typcache _cprec = null;
 //BA.debugLineNum = 383;BA.debugLine="Private Sub FindInCache(Position, PosPrec, Pos, PosMax As Int) As Int";
 //BA.debugLineNum = 385;BA.debugLine="Dim c As typCache";
_c = new www.computerdictionary.com.clsscrollpanel._typcache();
 //BA.debugLineNum = 386;BA.debugLine="c = Cache.Get(Pos)";
_c = (www.computerdictionary.com.clsscrollpanel._typcache)(_cache.Get((int)(Double.parseDouble(_pos))));
 //BA.debugLineNum = 387;BA.debugLine="If c.Top = Position Then Return c.Index";
if (_c.Top==(double)(Double.parseDouble(_position))) { 
if (true) return _c.Index;};
 //BA.debugLineNum = 388;BA.debugLine="Do While c.Top < Position";
while (_c.Top<(double)(Double.parseDouble(_position))) {
 //BA.debugLineNum = 390;BA.debugLine="PosPrec = Pos";
_posprec = _pos;
 //BA.debugLineNum = 391;BA.debugLine="Pos = Floor((Pos + PosMax) / 2)";
_pos = BA.NumberToString(__c.Floor(((double)(Double.parseDouble(_pos))+_posmax)/(double)2));
 //BA.debugLineNum = 392;BA.debugLine="c = Cache.Get(Pos)";
_c = (www.computerdictionary.com.clsscrollpanel._typcache)(_cache.Get((int)(Double.parseDouble(_pos))));
 //BA.debugLineNum = 393;BA.debugLine="If c.Top = Position Then Return c.Index";
if (_c.Top==(double)(Double.parseDouble(_position))) { 
if (true) return _c.Index;};
 //BA.debugLineNum = 394;BA.debugLine="If Pos = PosPrec Then";
if ((_pos).equals(_posprec)) { 
 //BA.debugLineNum = 396;BA.debugLine="If PosMax = Cache.Size Then";
if (_posmax==_cache.getSize()) { 
 //BA.debugLineNum = 397;BA.debugLine="Return c.Index";
if (true) return _c.Index;
 }else {
 //BA.debugLineNum = 399;BA.debugLine="Pos = PosMax";
_pos = BA.NumberToString(_posmax);
 //BA.debugLineNum = 400;BA.debugLine="c = Cache.Get(Pos)";
_c = (www.computerdictionary.com.clsscrollpanel._typcache)(_cache.Get((int)(Double.parseDouble(_pos))));
 };
 //BA.debugLineNum = 402;BA.debugLine="Exit";
if (true) break;
 };
 }
;
 //BA.debugLineNum = 407;BA.debugLine="If Pos - PosPrec = 1 Then";
if ((double)(Double.parseDouble(_pos))-(double)(Double.parseDouble(_posprec))==1) { 
 //BA.debugLineNum = 411;BA.debugLine="Dim cPrec As typCache";
_cprec = new www.computerdictionary.com.clsscrollpanel._typcache();
 //BA.debugLineNum = 412;BA.debugLine="cPrec = Cache.Get(PosPrec)";
_cprec = (www.computerdictionary.com.clsscrollpanel._typcache)(_cache.Get((int)(Double.parseDouble(_posprec))));
 //BA.debugLineNum = 413;BA.debugLine="If c.Top < Position + (getHeight / 2) AND cPrec.Top < Position Then";
if (_c.Top<(double)(Double.parseDouble(_position))+(_getheight()/(double)2) && _cprec.Top<(double)(Double.parseDouble(_position))) { 
 //BA.debugLineNum = 414;BA.debugLine="Return c.Index";
if (true) return _c.Index;
 }else {
 //BA.debugLineNum = 416;BA.debugLine="Return cPrec.Index";
if (true) return _cprec.Index;
 };
 }else {
 //BA.debugLineNum = 420;BA.debugLine="Return FindInCache(Position, PosPrec, Floor((PosPrec + Pos) / 2), Pos)";
if (true) return _findincache(_position,_posprec,BA.NumberToString(__c.Floor(((double)(Double.parseDouble(_posprec))+(double)(Double.parseDouble(_pos)))/(double)2)),(int)(Double.parseDouble(_pos)));
 };
 //BA.debugLineNum = 422;BA.debugLine="End Sub";
return 0;
}
public int  _getheight() throws Exception{
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
int _realheight = 0;
 //BA.debugLineNum = 140;BA.debugLine="Public Sub getHeight As Int";
 //BA.debugLineNum = 141;BA.debugLine="If sv.Height < 0 Then";
if (_sv.getHeight()<0) { 
 //BA.debugLineNum = 142;BA.debugLine="Dim r As Reflector, RealHeight As Int";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
_realheight = 0;
 //BA.debugLineNum = 143;BA.debugLine="r.Target = sv";
_r.Target = (Object)(_sv.getObject());
 //BA.debugLineNum = 144;BA.debugLine="RealHeight = r.RunMethod(\"getHeight\")";
_realheight = (int)(BA.ObjectToNumber(_r.RunMethod("getHeight")));
 //BA.debugLineNum = 145;BA.debugLine="If RealHeight = 0 Then";
if (_realheight==0) { 
 //BA.debugLineNum = 146;BA.debugLine="DoEvents";
__c.DoEvents();
 //BA.debugLineNum = 147;BA.debugLine="RealHeight = r.RunMethod(\"getHeight\")";
_realheight = (int)(BA.ObjectToNumber(_r.RunMethod("getHeight")));
 };
 //BA.debugLineNum = 149;BA.debugLine="Return RealHeight";
if (true) return _realheight;
 }else {
 //BA.debugLineNum = 151;BA.debugLine="Return sv.Height";
if (true) return _sv.getHeight();
 };
 //BA.debugLineNum = 153;BA.debugLine="End Sub";
return 0;
}
public anywheresoftware.b4a.objects.LabelWrapper  _getlabel() throws Exception{
 //BA.debugLineNum = 447;BA.debugLine="Public Sub GetLabel As Label";
 //BA.debugLineNum = 448;BA.debugLine="Return lblDisplay";
if (true) return _lbldisplay;
 //BA.debugLineNum = 449;BA.debugLine="End Sub";
return null;
}
public int  _getleft() throws Exception{
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
int _realleft = 0;
 //BA.debugLineNum = 90;BA.debugLine="Private Sub getLeft As Int";
 //BA.debugLineNum = 91;BA.debugLine="If sv.Left < 0 Then";
if (_sv.getLeft()<0) { 
 //BA.debugLineNum = 92;BA.debugLine="Dim r As Reflector, RealLeft As Int";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
_realleft = 0;
 //BA.debugLineNum = 93;BA.debugLine="r.Target = sv";
_r.Target = (Object)(_sv.getObject());
 //BA.debugLineNum = 94;BA.debugLine="RealLeft = r.RunMethod(\"getLeft\")";
_realleft = (int)(BA.ObjectToNumber(_r.RunMethod("getLeft")));
 //BA.debugLineNum = 95;BA.debugLine="If RealLeft = 0 Then";
if (_realleft==0) { 
 //BA.debugLineNum = 96;BA.debugLine="DoEvents";
__c.DoEvents();
 //BA.debugLineNum = 97;BA.debugLine="RealLeft = r.RunMethod(\"getLeft\")";
_realleft = (int)(BA.ObjectToNumber(_r.RunMethod("getLeft")));
 };
 //BA.debugLineNum = 99;BA.debugLine="Return RealLeft";
if (true) return _realleft;
 }else {
 //BA.debugLineNum = 101;BA.debugLine="Return sv.Left";
if (true) return _sv.getLeft();
 };
 //BA.debugLineNum = 103;BA.debugLine="End Sub";
return 0;
}
public String  _gettextfrom(anywheresoftware.b4a.objects.ConcreteViewWrapper _myview) throws Exception{
anywheresoftware.b4a.objects.PanelWrapper _pnl = null;
anywheresoftware.b4a.objects.ConcreteViewWrapper _v = null;
int _i = 0;
anywheresoftware.b4a.objects.LabelWrapper _lbl = null;
anywheresoftware.b4a.objects.EditTextWrapper _edt = null;
 //BA.debugLineNum = 199;BA.debugLine="Public Sub GetTextFrom(MyView As View) As String";
 //BA.debugLineNum = 200;BA.debugLine="If MyView.IsInitialized Then";
if (_myview.IsInitialized()) { 
 //BA.debugLineNum = 201;BA.debugLine="If IsPanel(MyView) Then";
if (_ispanel(_myview)) { 
 //BA.debugLineNum = 202;BA.debugLine="Dim pnl As Panel, v As View";
_pnl = new anywheresoftware.b4a.objects.PanelWrapper();
_v = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 //BA.debugLineNum = 203;BA.debugLine="pnl = MyView";
_pnl.setObject((android.view.ViewGroup)(_myview.getObject()));
 //BA.debugLineNum = 204;BA.debugLine="For i = 0 To pnl.NumberOfViews - 1";
{
final double step162 = 1;
final double limit162 = (int)(_pnl.getNumberOfViews()-1);
for (_i = (int)(0); (step162 > 0 && _i <= limit162) || (step162 < 0 && _i >= limit162); _i += step162) {
 //BA.debugLineNum = 205;BA.debugLine="v = pnl.GetView(i)";
_v = _pnl.GetView(_i);
 //BA.debugLineNum = 206;BA.debugLine="If IsLabel(v) OR IsEditText(v) Then";
if (_islabel(_v) || _isedittext(_v)) { 
 //BA.debugLineNum = 207;BA.debugLine="MyView = v";
_myview = _v;
 //BA.debugLineNum = 208;BA.debugLine="Exit";
if (true) break;
 };
 }
};
 };
 //BA.debugLineNum = 212;BA.debugLine="If IsLabel(MyView) Then";
if (_islabel(_myview)) { 
 //BA.debugLineNum = 213;BA.debugLine="Dim lbl As Label";
_lbl = new anywheresoftware.b4a.objects.LabelWrapper();
 //BA.debugLineNum = 214;BA.debugLine="lbl = MyView";
_lbl.setObject((android.widget.TextView)(_myview.getObject()));
 //BA.debugLineNum = 215;BA.debugLine="Return lbl.Text";
if (true) return _lbl.getText();
 }else if(_isedittext(_myview)) { 
 //BA.debugLineNum = 217;BA.debugLine="Dim edt As EditText";
_edt = new anywheresoftware.b4a.objects.EditTextWrapper();
 //BA.debugLineNum = 218;BA.debugLine="edt = MyView";
_edt.setObject((android.widget.EditText)(_myview.getObject()));
 //BA.debugLineNum = 219;BA.debugLine="Return edt.Text";
if (true) return _edt.getText();
 };
 };
 //BA.debugLineNum = 222;BA.debugLine="Return \"\"";
if (true) return "";
 //BA.debugLineNum = 223;BA.debugLine="End Sub";
return "";
}
public int  _gettop() throws Exception{
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
int _realtop = 0;
 //BA.debugLineNum = 106;BA.debugLine="Private Sub getTop As Int";
 //BA.debugLineNum = 107;BA.debugLine="If sv.Top < 0 Then";
if (_sv.getTop()<0) { 
 //BA.debugLineNum = 108;BA.debugLine="Dim r As Reflector, RealTop As Int";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
_realtop = 0;
 //BA.debugLineNum = 109;BA.debugLine="r.Target = sv";
_r.Target = (Object)(_sv.getObject());
 //BA.debugLineNum = 110;BA.debugLine="RealTop = r.RunMethod(\"getTop\")";
_realtop = (int)(BA.ObjectToNumber(_r.RunMethod("getTop")));
 //BA.debugLineNum = 111;BA.debugLine="If RealTop = 0 Then";
if (_realtop==0) { 
 //BA.debugLineNum = 112;BA.debugLine="DoEvents";
__c.DoEvents();
 //BA.debugLineNum = 113;BA.debugLine="RealTop = r.RunMethod(\"getTop\")";
_realtop = (int)(BA.ObjectToNumber(_r.RunMethod("getTop")));
 };
 //BA.debugLineNum = 115;BA.debugLine="Return RealTop";
if (true) return _realtop;
 }else {
 //BA.debugLineNum = 117;BA.debugLine="Return sv.Top";
if (true) return _sv.getTop();
 };
 //BA.debugLineNum = 119;BA.debugLine="End Sub";
return 0;
}
public anywheresoftware.b4a.objects.ConcreteViewWrapper  _gettopmostview(int _position) throws Exception{
int _wintop = 0;
int _winbottom = 0;
anywheresoftware.b4a.objects.ConcreteViewWrapper _v = null;
anywheresoftware.b4a.objects.ConcreteViewWrapper _bestcandidate = null;
int _i = 0;
 //BA.debugLineNum = 171;BA.debugLine="Public Sub GetTopMostView(Position As Int) As View";
 //BA.debugLineNum = 172;BA.debugLine="If sv.Panel.NumberOfViews = 0 Then Return sv";
if (_sv.getPanel().getNumberOfViews()==0) { 
if (true) return (anywheresoftware.b4a.objects.ConcreteViewWrapper) anywheresoftware.b4a.AbsObjectWrapper.ConvertToWrapper(new anywheresoftware.b4a.objects.ConcreteViewWrapper(), (android.view.View)(_sv.getObject()));};
 //BA.debugLineNum = 174;BA.debugLine="If bUseCache AND Cache.Size > 3 Then";
if (_busecache && _cache.getSize()>3) { 
 //BA.debugLineNum = 175;BA.debugLine="Return sv.Panel.GetView(FindInCache(Position, 0, Floor(Cache.Size / 2), Cache.Size))";
if (true) return _sv.getPanel().GetView(_findincache(BA.NumberToString(_position),BA.NumberToString(0),BA.NumberToString(__c.Floor(_cache.getSize()/(double)2)),_cache.getSize()));
 }else {
 //BA.debugLineNum = 177;BA.debugLine="Dim winTop, winBottom As Int";
_wintop = 0;
_winbottom = 0;
 //BA.debugLineNum = 178;BA.debugLine="winTop = Position";
_wintop = _position;
 //BA.debugLineNum = 179;BA.debugLine="winBottom = Position + (getHeight / 2)";
_winbottom = (int)(_position+(_getheight()/(double)2));
 //BA.debugLineNum = 180;BA.debugLine="Dim v, BestCandidate As View";
_v = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
_bestcandidate = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 //BA.debugLineNum = 181;BA.debugLine="BestCandidate = sv.Panel.GetView(0)";
_bestcandidate = _sv.getPanel().GetView((int)(0));
 //BA.debugLineNum = 182;BA.debugLine="For i = 0 To sv.Panel.NumberOfViews - 1";
{
final double step143 = 1;
final double limit143 = (int)(_sv.getPanel().getNumberOfViews()-1);
for (_i = (int)(0); (step143 > 0 && _i <= limit143) || (step143 < 0 && _i >= limit143); _i += step143) {
 //BA.debugLineNum = 183;BA.debugLine="v = sv.Panel.GetView(i)";
_v = _sv.getPanel().GetView(_i);
 //BA.debugLineNum = 184;BA.debugLine="If v.Top = winTop Then Return v ' We cannot find a better candidate";
if (_v.getTop()==_wintop) { 
if (true) return _v;};
 //BA.debugLineNum = 185;BA.debugLine="If v.Top < winBottom Then";
if (_v.getTop()<_winbottom) { 
 //BA.debugLineNum = 186;BA.debugLine="If (v.Top > BestCandidate.Top AND BestCandidate.Top < winTop) OR _ 					(v.Top < BestCandidate.Top AND BestCandidate.Top > winTop AND v.Top > winTop) Then";
if ((_v.getTop()>_bestcandidate.getTop() && _bestcandidate.getTop()<_wintop) || (_v.getTop()<_bestcandidate.getTop() && _bestcandidate.getTop()>_wintop && _v.getTop()>_wintop)) { 
 //BA.debugLineNum = 188;BA.debugLine="BestCandidate = v";
_bestcandidate = _v;
 };
 }else if(_bestcandidate.getTop()>=_winbottom && _v.getTop()<_bestcandidate.getTop()) { 
 //BA.debugLineNum = 191;BA.debugLine="BestCandidate = v";
_bestcandidate = _v;
 };
 }
};
 //BA.debugLineNum = 194;BA.debugLine="Return BestCandidate";
if (true) return _bestcandidate;
 };
 //BA.debugLineNum = 196;BA.debugLine="End Sub";
return null;
}
public String  _gettoptext() throws Exception{
anywheresoftware.b4a.objects.ConcreteViewWrapper _tmv = null;
 //BA.debugLineNum = 226;BA.debugLine="Private Sub GetTopText As String";
 //BA.debugLineNum = 227;BA.debugLine="Dim tmv As View";
_tmv = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 //BA.debugLineNum = 228;BA.debugLine="tmv = GetTopMostView(sv.ScrollPosition)";
_tmv = _gettopmostview(_sv.getScrollPosition());
 //BA.debugLineNum = 229;BA.debugLine="Return GetTextFrom(tmv)";
if (true) return _gettextfrom(_tmv);
 //BA.debugLineNum = 230;BA.debugLine="End Sub";
return "";
}
public int  _getwidth() throws Exception{
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
int _realwidth = 0;
 //BA.debugLineNum = 123;BA.debugLine="Public Sub getWidth As Int";
 //BA.debugLineNum = 124;BA.debugLine="If sv.Width < 0 Then";
if (_sv.getWidth()<0) { 
 //BA.debugLineNum = 125;BA.debugLine="Dim r As Reflector, RealWidth As Int";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
_realwidth = 0;
 //BA.debugLineNum = 126;BA.debugLine="r.Target = sv";
_r.Target = (Object)(_sv.getObject());
 //BA.debugLineNum = 127;BA.debugLine="RealWidth = r.RunMethod(\"getWidth\")";
_realwidth = (int)(BA.ObjectToNumber(_r.RunMethod("getWidth")));
 //BA.debugLineNum = 128;BA.debugLine="If RealWidth = 0 Then";
if (_realwidth==0) { 
 //BA.debugLineNum = 129;BA.debugLine="DoEvents";
__c.DoEvents();
 //BA.debugLineNum = 130;BA.debugLine="RealWidth = r.RunMethod(\"getWidth\")";
_realwidth = (int)(BA.ObjectToNumber(_r.RunMethod("getWidth")));
 };
 //BA.debugLineNum = 132;BA.debugLine="Return RealWidth";
if (true) return _realwidth;
 }else {
 //BA.debugLineNum = 134;BA.debugLine="Return sv.Width";
if (true) return _sv.getWidth();
 };
 //BA.debugLineNum = 136;BA.debugLine="End Sub";
return 0;
}
public String  _initialize(anywheresoftware.b4a.BA _ba,anywheresoftware.b4a.objects.ScrollViewWrapper _bindto,String _width,int _height,boolean _usecache) throws Exception{
innerInitialize(_ba);
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
anywheresoftware.b4a.objects.PanelWrapper _svparent = null;
 //BA.debugLineNum = 28;BA.debugLine="Public Sub Initialize(BindTo As ScrollView, Width, Height As Int, UseCache As Boolean)";
 //BA.debugLineNum = 29;BA.debugLine="sv = BindTo";
_sv = _bindto;
 //BA.debugLineNum = 30;BA.debugLine="Width = Max(Width, 50dip)";
_width = BA.NumberToString(__c.Max((double)(Double.parseDouble(_width)),__c.DipToCurrent((int)(50))));
 //BA.debugLineNum = 31;BA.debugLine="Height = Max(Height, 50dip)";
_height = (int)(__c.Max(_height,__c.DipToCurrent((int)(50))));
 //BA.debugLineNum = 33;BA.debugLine="pnlRange.Initialize(\"pnl\")";
_pnlrange.Initialize(ba,"pnl");
 //BA.debugLineNum = 34;BA.debugLine="Dim r As Reflector";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
 //BA.debugLineNum = 35;BA.debugLine="r.Target = BindTo";
_r.Target = (Object)(_bindto.getObject());
 //BA.debugLineNum = 36;BA.debugLine="Dim svParent As Panel";
_svparent = new anywheresoftware.b4a.objects.PanelWrapper();
 //BA.debugLineNum = 37;BA.debugLine="svParent = r.RunMethod(\"getParent\")";
_svparent.setObject((android.view.ViewGroup)(_r.RunMethod("getParent")));
 //BA.debugLineNum = 38;BA.debugLine="svParent.AddView(pnlRange, getLeft + getWidth - Width, getTop, Width, getHeight)";
_svparent.AddView((android.view.View)(_pnlrange.getObject()),(int)(_getleft()+_getwidth()-(double)(Double.parseDouble(_width))),_gettop(),(int)(Double.parseDouble(_width)),_getheight());
 //BA.debugLineNum = 39;BA.debugLine="pnlRange.Visible = False";
_pnlrange.setVisible(__c.False);
 //BA.debugLineNum = 41;BA.debugLine="pnlDisplay.Initialize(\"\")";
_pnldisplay.Initialize(ba,"");
 //BA.debugLineNum = 42;BA.debugLine="pnlRange.AddView(pnlDisplay, 0, 0, Width, Height)";
_pnlrange.AddView((android.view.View)(_pnldisplay.getObject()),(int)(0),(int)(0),(int)(Double.parseDouble(_width)),_height);
 //BA.debugLineNum = 43;BA.debugLine="pnlDisplay.Background = LoadDrawable(\"toast_frame\")";
_pnldisplay.setBackground((android.graphics.drawable.Drawable)(_loaddrawable("toast_frame")));
 //BA.debugLineNum = 45;BA.debugLine="MinPos = -5dip";
_minpos = (int)(-__c.DipToCurrent((int)(5)));
 //BA.debugLineNum = 46;BA.debugLine="MaxPos = pnlRange.Height - pnlDisplay.Height + 15dip";
_maxpos = (int)(_pnlrange.getHeight()-_pnldisplay.getHeight()+__c.DipToCurrent((int)(15)));
 //BA.debugLineNum = 47;BA.debugLine="bUserMovingPnl = False 'Becomes True when the user moves the ScrollPanel";
_busermovingpnl = __c.False;
 //BA.debugLineNum = 49;BA.debugLine="lblDisplay.Initialize(\"\")";
_lbldisplay.Initialize(ba,"");
 //BA.debugLineNum = 50;BA.debugLine="lblDisplay.Gravity = Gravity.CENTER_VERTICAL + Gravity.CENTER_HORIZONTAL";
_lbldisplay.setGravity((int)(__c.Gravity.CENTER_VERTICAL+__c.Gravity.CENTER_HORIZONTAL));
 //BA.debugLineNum = 51;BA.debugLine="lblDisplay.TextColor = Colors.White";
_lbldisplay.setTextColor(__c.Colors.White);
 //BA.debugLineNum = 52;BA.debugLine="lblDisplay.TextSize = 18";
_lbldisplay.setTextSize((float)(18));
 //BA.debugLineNum = 53;BA.debugLine="lblDisplay.Typeface = Typeface.DEFAULT_BOLD";
_lbldisplay.setTypeface(__c.Typeface.DEFAULT_BOLD);
 //BA.debugLineNum = 54;BA.debugLine="pnlDisplay.AddView(lblDisplay, 28dip, 16dip, pnlDisplay.Width - 56dip, pnlDisplay.Height - 38dip)";
_pnldisplay.AddView((android.view.View)(_lbldisplay.getObject()),__c.DipToCurrent((int)(28)),__c.DipToCurrent((int)(16)),(int)(_pnldisplay.getWidth()-__c.DipToCurrent((int)(56))),(int)(_pnldisplay.getHeight()-__c.DipToCurrent((int)(38))));
 //BA.debugLineNum = 56;BA.debugLine="TimeOut.Initialize(\"TimeOut\", 0)";
_timeout.Initialize(ba,"TimeOut",(long)(0));
 //BA.debugLineNum = 57;BA.debugLine="Anim.InitializeTranslate(\"Anim\", 0, 0, Width, 0)";
_anim.InitializeTranslate(ba,"Anim",(float)(0),(float)(0),(float)(Double.parseDouble(_width)),(float)(0));
 //BA.debugLineNum = 58;BA.debugLine="Anim.Duration = Duration";
_anim.setDuration((long)(_duration));
 //BA.debugLineNum = 59;BA.debugLine="Anim.RepeatCount = 0";
_anim.setRepeatCount((int)(0));
 //BA.debugLineNum = 61;BA.debugLine="bUseCache = UseCache";
_busecache = _usecache;
 //BA.debugLineNum = 62;BA.debugLine="If bUseCache Then";
if (_busecache) { 
 //BA.debugLineNum = 63;BA.debugLine="Cache.Initialize";
_cache.Initialize();
 //BA.debugLineNum = 64;BA.debugLine="RefreshCache";
_refreshcache();
 };
 //BA.debugLineNum = 67;BA.debugLine="CallbackShowHide = Null";
_callbackshowhide = __c.Null;
 //BA.debugLineNum = 68;BA.debugLine="CallbackTextUpdated = Null";
_callbacktextupdated = __c.Null;
 //BA.debugLineNum = 70;BA.debugLine="bWaitForScroll = True";
_bwaitforscroll = __c.True;
 //BA.debugLineNum = 71;BA.debugLine="pnlDisplay.Top = CalcNewTop";
_pnldisplay.setTop((int)(Double.parseDouble(_calcnewtop())));
 //BA.debugLineNum = 72;BA.debugLine="End Sub";
return "";
}
public boolean  _isedittext(anywheresoftware.b4a.objects.ConcreteViewWrapper _myview) throws Exception{
 //BA.debugLineNum = 161;BA.debugLine="Private Sub IsEditText(MyView As View) As Boolean";
 //BA.debugLineNum = 162;BA.debugLine="Return (GetType(MyView) = \"android.widget.EditText\")";
if (true) return ((__c.GetType((Object)(_myview.getObject()))).equals("android.widget.EditText"));
 //BA.debugLineNum = 163;BA.debugLine="End Sub";
return false;
}
public boolean  _islabel(anywheresoftware.b4a.objects.ConcreteViewWrapper _myview) throws Exception{
 //BA.debugLineNum = 157;BA.debugLine="Private Sub IsLabel(MyView As View) As Boolean";
 //BA.debugLineNum = 158;BA.debugLine="Return (GetType(MyView) = \"android.widget.TextView\")";
if (true) return ((__c.GetType((Object)(_myview.getObject()))).equals("android.widget.TextView"));
 //BA.debugLineNum = 159;BA.debugLine="End Sub";
return false;
}
public boolean  _ispanel(anywheresoftware.b4a.objects.ConcreteViewWrapper _myview) throws Exception{
 //BA.debugLineNum = 165;BA.debugLine="Private Sub IsPanel(MyView As View) As Boolean";
 //BA.debugLineNum = 166;BA.debugLine="Return (MyView Is Panel)";
if (true) return (_myview.getObjectOrNull() instanceof android.view.ViewGroup);
 //BA.debugLineNum = 167;BA.debugLine="End Sub";
return false;
}
public Object  _loaddrawable(String _name) throws Exception{
anywheresoftware.b4a.agraham.reflection.Reflection _r = null;
int _id_drawable = 0;
 //BA.debugLineNum = 75;BA.debugLine="Public Sub LoadDrawable(Name As String) As Object";
 //BA.debugLineNum = 76;BA.debugLine="Dim r As Reflector";
_r = new anywheresoftware.b4a.agraham.reflection.Reflection();
 //BA.debugLineNum = 77;BA.debugLine="r.Target = r.GetContext";
_r.Target = (Object)(_r.GetContext(ba));
 //BA.debugLineNum = 78;BA.debugLine="r.Target = r.RunMethod(\"getResources\")";
_r.Target = _r.RunMethod("getResources");
 //BA.debugLineNum = 79;BA.debugLine="r.Target = r.RunMethod(\"getSystem\")";
_r.Target = _r.RunMethod("getSystem");
 //BA.debugLineNum = 80;BA.debugLine="Dim ID_Drawable As Int";
_id_drawable = 0;
 //BA.debugLineNum = 81;BA.debugLine="ID_Drawable = r.RunMethod4(\"getIdentifier\", Array As Object(Name, \"drawable\", \"android\"), _ 	                                            Array As String(\"java.lang.String\", \"java.lang.String\", \"java.lang.String\"))";
_id_drawable = (int)(BA.ObjectToNumber(_r.RunMethod4("getIdentifier",new Object[]{(Object)(_name),(Object)("drawable"),(Object)("android")},new String[]{"java.lang.String","java.lang.String","java.lang.String"})));
 //BA.debugLineNum = 83;BA.debugLine="r.Target = r.GetContext";
_r.Target = (Object)(_r.GetContext(ba));
 //BA.debugLineNum = 84;BA.debugLine="r.Target = r.RunMethod(\"getResources\")";
_r.Target = _r.RunMethod("getResources");
 //BA.debugLineNum = 85;BA.debugLine="Return r.RunMethod2(\"getDrawable\", ID_Drawable, \"java.lang.int\")";
if (true) return _r.RunMethod2("getDrawable",BA.NumberToString(_id_drawable),"java.lang.int");
 //BA.debugLineNum = 86;BA.debugLine="End Sub";
return null;
}
public String  _pnl_touch(int _action,float _x,float _y) throws Exception{
 //BA.debugLineNum = 315;BA.debugLine="Private Sub pnl_Touch(Action As Int, X As Float, Y As Float)";
 //BA.debugLineNum = 316;BA.debugLine="Select Case Action";
switch (_action) {
case 0:
case 2:
 //BA.debugLineNum = 318;BA.debugLine="bUserMovingPnl = True";
_busermovingpnl = __c.True;
 //BA.debugLineNum = 319;BA.debugLine="TimeOut.Enabled = False";
_timeout.setEnabled(__c.False);
 //BA.debugLineNum = 320;BA.debugLine="Anim.Stop(pnlDisplay)";
_anim.Stop((android.view.View)(_pnldisplay.getObject()));
 //BA.debugLineNum = 321;BA.debugLine="pnlDisplay.Top = Min(Max(MinPos, Y * (1 - (pnlDisplay.Height / pnlRange.Height))), MinPos + MaxPos)";
_pnldisplay.setTop((int)(__c.Min(__c.Max(_minpos,_y*(1-(_pnldisplay.getHeight()/(double)_pnlrange.getHeight()))),_minpos+_maxpos)));
 //BA.debugLineNum = 322;BA.debugLine="sv.ScrollPosition = (pnlDisplay.Top - MinPos) / MaxPos * (sv.Panel.Height - getHeight)";
_sv.setScrollPosition((int)((_pnldisplay.getTop()-_minpos)/(double)_maxpos*(_sv.getPanel().getHeight()-_getheight())));
 break;
default:
 //BA.debugLineNum = 324;BA.debugLine="bUserMovingPnl = False";
_busermovingpnl = __c.False;
 //BA.debugLineNum = 325;BA.debugLine="TimeOut.Interval = Duration";
_timeout.setInterval((long)(_duration));
 //BA.debugLineNum = 326;BA.debugLine="TimeOut.Enabled = True";
_timeout.setEnabled(__c.True);
 break;
}
;
 //BA.debugLineNum = 328;BA.debugLine="End Sub";
return "";
}
public String  _raiseshowhide(boolean _visible) throws Exception{
 //BA.debugLineNum = 339;BA.debugLine="Private Sub RaiseShowHide(Visible As Boolean)";
 //BA.debugLineNum = 341;BA.debugLine="If CallbackShowHide <> Null Then";
if (_callbackshowhide!= null) { 
 //BA.debugLineNum = 342;BA.debugLine="If SubExists(CallbackShowHide, ShowHideSubName) Then";
if (__c.SubExists(ba,_callbackshowhide,_showhidesubname)) { 
 //BA.debugLineNum = 343;BA.debugLine="CallSub3(CallbackShowHide, ShowHideSubName, Me, Visible)";
__c.CallSub3(ba,_callbackshowhide,_showhidesubname,this,(Object)(_visible));
 };
 };
 //BA.debugLineNum = 346;BA.debugLine="End Sub";
return "";
}
public String  _raisetextupdated(String _text) throws Exception{
 //BA.debugLineNum = 356;BA.debugLine="Private Sub RaiseTextUpdated(Text As String)";
 //BA.debugLineNum = 358;BA.debugLine="If CallbackTextUpdated <> Null Then";
if (_callbacktextupdated!= null) { 
 //BA.debugLineNum = 359;BA.debugLine="If SubExists(CallbackTextUpdated, TextUpdatedSubName) Then";
if (__c.SubExists(ba,_callbacktextupdated,_textupdatedsubname)) { 
 //BA.debugLineNum = 360;BA.debugLine="CallSub3(CallbackTextUpdated, TextUpdatedSubName, Me, Text)";
__c.CallSub3(ba,_callbacktextupdated,_textupdatedsubname,this,(Object)(_text));
 };
 };
 //BA.debugLineNum = 363;BA.debugLine="End Sub";
return "";
}
public String  _refreshcache() throws Exception{
anywheresoftware.b4a.objects.ConcreteViewWrapper _v = null;
int _i = 0;
www.computerdictionary.com.clsscrollpanel._typcache _c = null;
 //BA.debugLineNum = 369;BA.debugLine="Public Sub RefreshCache";
 //BA.debugLineNum = 370;BA.debugLine="Cache.Clear";
_cache.Clear();
 //BA.debugLineNum = 371;BA.debugLine="If Not(bUseCache) Then Return";
if (__c.Not(_busecache)) { 
if (true) return "";};
 //BA.debugLineNum = 372;BA.debugLine="Dim v As View";
_v = new anywheresoftware.b4a.objects.ConcreteViewWrapper();
 //BA.debugLineNum = 373;BA.debugLine="For i = 0 To sv.Panel.NumberOfViews - 1";
{
final double step291 = 1;
final double limit291 = (int)(_sv.getPanel().getNumberOfViews()-1);
for (_i = (int)(0); (step291 > 0 && _i <= limit291) || (step291 < 0 && _i >= limit291); _i += step291) {
 //BA.debugLineNum = 374;BA.debugLine="v = sv.Panel.GetView(i)";
_v = _sv.getPanel().GetView(_i);
 //BA.debugLineNum = 375;BA.debugLine="Dim c As typCache";
_c = new www.computerdictionary.com.clsscrollpanel._typcache();
 //BA.debugLineNum = 376;BA.debugLine="c.Top = v.Top";
_c.Top = _v.getTop();
 //BA.debugLineNum = 377;BA.debugLine="c.Index = i";
_c.Index = _i;
 //BA.debugLineNum = 378;BA.debugLine="Cache.Add(c)";
_cache.Add((Object)(_c));
 }
};
 //BA.debugLineNum = 380;BA.debugLine="Cache.SortType(\"Top\", True)";
_cache.SortType("Top",__c.True);
 //BA.debugLineNum = 381;BA.debugLine="End Sub";
return "";
}
public String  _remove() throws Exception{
 //BA.debugLineNum = 457;BA.debugLine="Public Sub Remove";
 //BA.debugLineNum = 458;BA.debugLine="Anim.Stop(pnlDisplay)";
_anim.Stop((android.view.View)(_pnldisplay.getObject()));
 //BA.debugLineNum = 459;BA.debugLine="TimeOut.Enabled = False";
_timeout.setEnabled(__c.False);
 //BA.debugLineNum = 460;BA.debugLine="lblDisplay.RemoveView";
_lbldisplay.RemoveView();
 //BA.debugLineNum = 461;BA.debugLine="lblDisplay = Null";
_lbldisplay.setObject((android.widget.TextView)(__c.Null));
 //BA.debugLineNum = 462;BA.debugLine="pnlDisplay.RemoveView";
_pnldisplay.RemoveView();
 //BA.debugLineNum = 463;BA.debugLine="pnlDisplay = Null";
_pnldisplay.setObject((android.view.ViewGroup)(__c.Null));
 //BA.debugLineNum = 464;BA.debugLine="pnlRange.RemoveView";
_pnlrange.RemoveView();
 //BA.debugLineNum = 465;BA.debugLine="pnlRange = Null";
_pnlrange.setObject((android.view.ViewGroup)(__c.Null));
 //BA.debugLineNum = 466;BA.debugLine="CallbackShowHide = Null";
_callbackshowhide = __c.Null;
 //BA.debugLineNum = 467;BA.debugLine="CallbackTextUpdated = Null";
_callbacktextupdated = __c.Null;
 //BA.debugLineNum = 468;BA.debugLine="Cache.Clear";
_cache.Clear();
 //BA.debugLineNum = 469;BA.debugLine="End Sub";
return "";
}
public String  _replacebackground(Object _newbackground) throws Exception{
anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper _bmp = null;
 //BA.debugLineNum = 427;BA.debugLine="Public Sub ReplaceBackground(NewBackground As Object)";
 //BA.debugLineNum = 428;BA.debugLine="If pnlDisplay.IsInitialized AND NewBackground <> Null Then";
if (_pnldisplay.IsInitialized() && _newbackground!= null) { 
 //BA.debugLineNum = 429;BA.debugLine="lblDisplay.RemoveView";
_lbldisplay.RemoveView();
 //BA.debugLineNum = 430;BA.debugLine="If NewBackground Is Bitmap Then";
if (_newbackground instanceof android.graphics.Bitmap) { 
 //BA.debugLineNum = 431;BA.debugLine="pnlDisplay.RemoveView     'We cannot do a SetLayout because of the default";
_pnldisplay.RemoveView();
 //BA.debugLineNum = 432;BA.debugLine="pnlDisplay.Initialize(\"\") 'background padding so we reinitialize the panel";
_pnldisplay.Initialize(ba,"");
 //BA.debugLineNum = 433;BA.debugLine="Dim bmp As Bitmap";
_bmp = new anywheresoftware.b4a.objects.drawable.CanvasWrapper.BitmapWrapper();
 //BA.debugLineNum = 434;BA.debugLine="bmp = NewBackground";
_bmp.setObject((android.graphics.Bitmap)(_newbackground));
 //BA.debugLineNum = 435;BA.debugLine="pnlRange.AddView(pnlDisplay, 0, 0, bmp.Width, bmp.Height)";
_pnlrange.AddView((android.view.View)(_pnldisplay.getObject()),(int)(0),(int)(0),_bmp.getWidth(),_bmp.getHeight());
 //BA.debugLineNum = 436;BA.debugLine="pnlDisplay.SetBackgroundImage(bmp)";
_pnldisplay.SetBackgroundImage((android.graphics.Bitmap)(_bmp.getObject()));
 }else {
 //BA.debugLineNum = 438;BA.debugLine="pnlDisplay.Background = NewBackground";
_pnldisplay.setBackground((android.graphics.drawable.Drawable)(_newbackground));
 };
 //BA.debugLineNum = 440;BA.debugLine="pnlDisplay.AddView(lblDisplay, 3dip, 3dip, pnlDisplay.Width - 6dip, pnlDisplay.Height - 6dip)";
_pnldisplay.AddView((android.view.View)(_lbldisplay.getObject()),__c.DipToCurrent((int)(3)),__c.DipToCurrent((int)(3)),(int)(_pnldisplay.getWidth()-__c.DipToCurrent((int)(6))),(int)(_pnldisplay.getHeight()-__c.DipToCurrent((int)(6))));
 //BA.debugLineNum = 441;BA.debugLine="MinPos = 0";
_minpos = (int)(0);
 //BA.debugLineNum = 442;BA.debugLine="MaxPos = pnlRange.Height - pnlDisplay.Height";
_maxpos = (int)(_pnlrange.getHeight()-_pnldisplay.getHeight());
 };
 //BA.debugLineNum = 444;BA.debugLine="End Sub";
return "";
}
public boolean  _scrollpanelmovedbyuser() throws Exception{
 //BA.debugLineNum = 452;BA.debugLine="Public Sub ScrollPanelMovedByUser As Boolean";
 //BA.debugLineNum = 453;BA.debugLine="Return bUserMovingPnl";
if (true) return _busermovingpnl;
 //BA.debugLineNum = 454;BA.debugLine="End Sub";
return false;
}
public String  _setonshowhideevent(Object _callback,String _subname) throws Exception{
 //BA.debugLineNum = 334;BA.debugLine="Public Sub SetOnShowHideEvent(Callback As Object, SubName As String)";
 //BA.debugLineNum = 335;BA.debugLine="CallbackShowHide = Callback";
_callbackshowhide = _callback;
 //BA.debugLineNum = 336;BA.debugLine="ShowHideSubName = SubName";
_showhidesubname = _subname;
 //BA.debugLineNum = 337;BA.debugLine="End Sub";
return "";
}
public String  _setontextupdatedevent(Object _callback,String _subname) throws Exception{
 //BA.debugLineNum = 351;BA.debugLine="Public Sub SetOnTextUpdatedEvent(Callback As Object, SubName As String)";
 //BA.debugLineNum = 352;BA.debugLine="CallbackTextUpdated = Callback";
_callbacktextupdated = _callback;
 //BA.debugLineNum = 353;BA.debugLine="TextUpdatedSubName = SubName";
_textupdatedsubname = _subname;
 //BA.debugLineNum = 354;BA.debugLine="End Sub";
return "";
}
public String  _timeout_tick() throws Exception{
 //BA.debugLineNum = 305;BA.debugLine="Private Sub TimeOut_Tick";
 //BA.debugLineNum = 306;BA.debugLine="TimeOut.Enabled = False";
_timeout.setEnabled(__c.False);
 //BA.debugLineNum = 307;BA.debugLine="Anim.Start(pnlDisplay)";
_anim.Start((android.view.View)(_pnldisplay.getObject()));
 //BA.debugLineNum = 308;BA.debugLine="RaiseShowHide(False)";
_raiseshowhide(__c.False);
 //BA.debugLineNum = 309;BA.debugLine="End Sub";
return "";
}
}
