Type=Class
Version=2.52
@EndOfDesignText@
'Class module
'Version 1.4
Sub Class_Globals
	Private sv As ScrollView
	Private pnlRange As Panel
	Private pnlDisplay As Panel
	Private lblDisplay As Label
	Private CallbackShowHide As Object
	Private CallbackTextUpdated As Object
	Private ShowHideSubName As String
	Private TextUpdatedSubName As String
	Private Anim As Animation
	Private TimeOut As Timer
	Private Duration As Int: Duration = 400
	Private MinPos, MaxPos As Int
	Private bUserMovingPnl As Boolean
	Private bWaitForScroll As Boolean
	Private bUseCache As Boolean
	Private Cache As List
	Type typCache(Top As Int, Index As Int)
End Sub

'Initializes the ScrollPanel.
'BindTo = an initialized scrollview.
'Width and Height = dimensions of the ScrollPanel.
'UseCache = if True, improves the speed of GetTopMostView (used by Display functions) with heavy loaded ScrollViews.
' If you change the ScrollView content, you must call RefreshCache.
Public Sub Initialize(BindTo As ScrollView, Width, Height As Int, UseCache As Boolean)
	sv = BindTo
	Width = Max(Width, 50dip)
	Height = Max(Height, 50dip)

	pnlRange.Initialize("pnl")
	Dim r As Reflector
	r.Target = BindTo
	Dim svParent As Panel
	svParent = r.RunMethod("getParent")
	svParent.AddView(pnlRange, getLeft + getWidth - Width, getTop, Width, getHeight)
	pnlRange.Visible = False

	pnlDisplay.Initialize("")
	pnlRange.AddView(pnlDisplay, 0, 0, Width, Height)
	pnlDisplay.Background = LoadDrawable("toast_frame")

	MinPos = -5dip
	MaxPos = pnlRange.Height - pnlDisplay.Height + 15dip
	bUserMovingPnl = False 'Becomes True when the user moves the ScrollPanel

	lblDisplay.Initialize("")
	lblDisplay.Gravity = Gravity.CENTER_VERTICAL + Gravity.CENTER_HORIZONTAL
	lblDisplay.TextColor = Colors.White
	lblDisplay.TextSize = 18
	lblDisplay.Typeface = Typeface.DEFAULT_BOLD
	pnlDisplay.AddView(lblDisplay, 28dip, 16dip, pnlDisplay.Width - 56dip, pnlDisplay.Height - 38dip)

	TimeOut.Initialize("TimeOut", 0)
	Anim.InitializeTranslate("Anim", 0, 0, Width, 0)
	Anim.Duration = Duration
	Anim.RepeatCount = 0

	bUseCache = UseCache
	If bUseCache Then
		Cache.Initialize
		RefreshCache
	End If

	CallbackShowHide = Null
	CallbackTextUpdated = Null

	bWaitForScroll = True
	pnlDisplay.Top = CalcNewTop
End Sub

'Gets a drawable from the Android system resources
Public Sub LoadDrawable(Name As String) As Object
	Dim r As Reflector
	r.Target = r.GetContext
	r.Target = r.RunMethod("getResources")
	r.Target = r.RunMethod("getSystem")
	Dim ID_Drawable As Int
	ID_Drawable = r.RunMethod4("getIdentifier", Array As Object(Name, "drawable", "android"), _
	                                            Array As String("java.lang.String", "java.lang.String", "java.lang.String"))
	r.Target = r.GetContext
	r.Target = r.RunMethod("getResources")
	Return r.RunMethod2("getDrawable", ID_Drawable, "java.lang.int")
End Sub

#Region SV Left, Top, Width, Height
'Gets the ScrollView left in the parent coordinate space
Private Sub getLeft As Int
	If sv.Left < 0 Then
		Dim r As Reflector, RealLeft As Int
		r.Target = sv
		RealLeft = r.RunMethod("getLeft")
		If RealLeft = 0 Then
			DoEvents
			RealLeft = r.RunMethod("getLeft")
		End If
		Return RealLeft
	Else
		Return sv.Left
	End If
End Sub

'Gets the ScrollView top in the parent coordinate space
Private Sub getTop As Int
	If sv.Top < 0 Then
		Dim r As Reflector, RealTop As Int
		r.Target = sv
		RealTop = r.RunMethod("getTop")
		If RealTop = 0 Then
			DoEvents
			RealTop = r.RunMethod("getTop")
		End If
		Return RealTop
	Else
		Return sv.Top
	End If
End Sub

'Gets the real width of the ScrollView
'In some containers like TabHosts, the width property returns -1, so this function uses a different method to get width
Public Sub getWidth As Int
	If sv.Width < 0 Then
		Dim r As Reflector, RealWidth As Int
		r.Target = sv
		RealWidth = r.RunMethod("getWidth")
		If RealWidth = 0 Then
			DoEvents
			RealWidth = r.RunMethod("getWidth")
		End If
		Return RealWidth
	Else
		Return sv.Width
	End If
End Sub

'Gets the real height of the ScrollView
'In some containers like TabHosts, the height property returns -1, so this function uses a different method to get height
Public Sub getHeight As Int
	If sv.Height < 0 Then
		Dim r As Reflector, RealHeight As Int
		r.Target = sv
		RealHeight = r.RunMethod("getHeight")
		If RealHeight = 0 Then
			DoEvents
			RealHeight = r.RunMethod("getHeight")
		End If
		Return RealHeight
	Else
		Return sv.Height
	End If
End Sub
#End Region

#Region IsType
Private Sub IsLabel(MyView As View) As Boolean
	Return (GetType(MyView) = "android.widget.TextView")
End Sub

Private Sub IsEditText(MyView As View) As Boolean
	Return (GetType(MyView) = "android.widget.EditText")
End Sub

Private Sub IsPanel(MyView As View) As Boolean
	Return (MyView Is Panel)
End Sub
#End Region

'Gets the topmost view in the visible area of the ScrollView
Public Sub GetTopMostView(Position As Int) As View
	If sv.Panel.NumberOfViews = 0 Then Return sv

	If bUseCache AND Cache.Size > 3 Then
		Return sv.Panel.GetView(FindInCache(Position, 0, Floor(Cache.Size / 2), Cache.Size))
	Else
		Dim winTop, winBottom As Int
		winTop = Position
		winBottom = Position + (getHeight / 2)
		Dim v, BestCandidate As View
		BestCandidate = sv.Panel.GetView(0)
		For i = 0 To sv.Panel.NumberOfViews - 1
			v = sv.Panel.GetView(i)
			If v.Top = winTop Then Return v ' We cannot find a better candidate
			If v.Top < winBottom Then
				If (v.Top > BestCandidate.Top AND BestCandidate.Top < winTop) OR _
					(v.Top < BestCandidate.Top AND BestCandidate.Top > winTop AND v.Top > winTop) Then
					BestCandidate = v
				End If
			Else If BestCandidate.Top >= winBottom AND v.Top < BestCandidate.Top Then
				BestCandidate = v
			End If
		Next
		Return BestCandidate
	End If
End Sub

'Gets the text from the given view (we search among children if the view is a panel)
Public Sub GetTextFrom(MyView As View) As String
	If MyView.IsInitialized Then
		If IsPanel(MyView) Then
			Dim pnl As Panel, v As View
			pnl = MyView
			For i = 0 To pnl.NumberOfViews - 1
				v = pnl.GetView(i)
				If IsLabel(v) OR IsEditText(v) Then
					MyView = v
					Exit
				End If
			Next
		End If
		If IsLabel(MyView) Then
			Dim lbl As Label
			lbl = MyView
			Return lbl.Text
		Else If IsEditText(MyView) Then
			Dim edt As EditText
			edt = MyView
			Return edt.Text
		End If
	End If
	Return ""
End Sub

'Gets the text from the topmost view
Private Sub GetTopText As String
	Dim tmv As View
	tmv = GetTopMostView(sv.ScrollPosition)
	Return GetTextFrom(tmv)
End Sub

'Displays the first character found
Public Sub DisplayFirstChar(Position As Int)
	If pnlDisplay.IsInitialized Then
		Dim TopText As String
		TopText = GetTopText.Trim
		If TopText <> "" Then TopText = TopText.CharAt(0)
		DisplayPnl(Position, TopText.ToUpperCase)
	End If
End Sub

'Displays the first text line found
Public Sub DisplayTextLine(Position As Int)
	If pnlDisplay.IsInitialized Then
		Dim TopText As String
		TopText = GetTopText.Trim
		Dim PosCRLF As Int
		PosCRLF = TopText.IndexOf(CRLF)
		If PosCRLF > 0 Then TopText = TopText.SubString2(0, PosCRLF)
		DisplayPnl(Position, TopText)
	End If
End Sub

'Displays the first tag found
Public Sub DisplayTag(Position As Int)
	If pnlDisplay.IsInitialized Then
		DisplayPnl(Position, GetTopMostView(Position).Tag)
	End If
End Sub

'Displays a custom text (or nothing if Text = "")
Public Sub DisplayCustomText(Position As Int, Text As String)
	If pnlDisplay.IsInitialized Then
		DisplayPnl(Position, Text)
	End If
End Sub

'Returns the new panel top position
Private Sub CalcNewTop
	Return (sv.ScrollPosition / (sv.Panel.Height - getHeight) * MaxPos) + MinPos
End Sub

Private Sub DisplayPnl(Position As Int, Txt As String)
	lblDisplay.Text = Txt
	RaiseTextUpdated(Txt)

	If bWaitForScroll Then
		' We don't display the panel until the ScrollView starts scrolling
		If pnlDisplay.Top = CalcNewTop Then
			Return
		Else
			bWaitForScroll = False
		End If
	End If

	If sv.Panel.Height > getHeight Then
		' The panel is displayed only if the ScrollView doesn't show all items (a good reason to scroll)
		pnlRange.Visible = True
		RaiseShowHide(True)
	End If

	If Not(bUserMovingPnl) Then
		TimeOut.Enabled = False
		Anim.Stop(pnlDisplay)
 		pnlDisplay.Top = CalcNewTop
		If Position = sv.ScrollPosition Then
			' The scrolling is over but we wait a little bit before hiding the panel
			TimeOut.Interval = Duration
			TimeOut.Enabled = True
			bWaitForScroll = True
		End If
	End If
End Sub

Private Sub TimeOut_Tick
	TimeOut.Enabled = False
	Anim.Start(pnlDisplay)
	RaiseShowHide(False)
End Sub

Private Sub Anim_AnimationEnd
	pnlRange.Visible = False
End Sub

Private Sub pnl_Touch(Action As Int, X As Float, Y As Float)
	Select Case Action
		Case 0, 2:	' ACTION_DOWN or ACTION_MOVE
			bUserMovingPnl = True
			TimeOut.Enabled = False
			Anim.Stop(pnlDisplay)
			pnlDisplay.Top = Min(Max(MinPos, Y * (1 - (pnlDisplay.Height / pnlRange.Height))), MinPos + MaxPos)
			sv.ScrollPosition = (pnlDisplay.Top - MinPos) / MaxPos * (sv.Panel.Height - getHeight)
		Case Else:	' ACTION_UP
			bUserMovingPnl = False
			TimeOut.Interval = Duration
			TimeOut.Enabled = True
	End Select
End Sub

#Region Events
'Raises an event when the ScrollPanel shows or hides.
'Callback = Me
'The listener must be declared as <I>SubName</I> (SenderSP As Object, Visible As Boolean)
Public Sub SetOnShowHideEvent(Callback As Object, SubName As String)
	CallbackShowHide = Callback
	ShowHideSubName = SubName
End Sub

Private Sub RaiseShowHide(Visible As Boolean)
	' Raises a ShowHide event
	If CallbackShowHide <> Null Then
		If SubExists(CallbackShowHide, ShowHideSubName) Then
			CallSub3(CallbackShowHide, ShowHideSubName, Me, Visible)
		End If
	End If
End Sub

'Raises an event when the ScrollPanel text is updated.
'Callback = Me
'The listener must be declared as <I>SubName</I> (SenderSP As Object, Text As String)
Public Sub SetOnTextUpdatedEvent(Callback As Object, SubName As String)
	CallbackTextUpdated = Callback
	TextUpdatedSubName = SubName
End Sub

Private Sub RaiseTextUpdated(Text As String)
	' Raises a TextUpdated event
	If CallbackTextUpdated <> Null Then
		If SubExists(CallbackTextUpdated, TextUpdatedSubName) Then
			CallSub3(CallbackTextUpdated, TextUpdatedSubName, Me, Text)
		End If
	End If
End Sub
#End Region

#Region Cache
'Refreshes the cache used to improve speed.
'Must be called every time you modify the ScrollView content.
Public Sub RefreshCache
	Cache.Clear
	If Not(bUseCache) Then Return
	Dim v As View
	For i = 0 To sv.Panel.NumberOfViews - 1
		v = sv.Panel.GetView(i)
		Dim c As typCache
		c.Top = v.Top
		c.Index = i
		Cache.Add(c)
	Next
	Cache.SortType("Top", True)
End Sub

Private Sub FindInCache(Position, PosPrec, Pos, PosMax As Int) As Int
	' On recherche le meilleur candidat par dichotomie
	Dim c As typCache
	c = Cache.Get(Pos)
	If c.Top = Position Then Return c.Index
	Do While c.Top < Position
		' Le meilleur candidat se trouve après l'index actuel
		PosPrec = Pos
		Pos = Floor((Pos + PosMax) / 2)
		c = Cache.Get(Pos)
		If c.Top = Position Then Return c.Index
		If Pos = PosPrec Then
			' On tourne en rond -> on sélectionne le dernier candidat et on sort
			If PosMax = Cache.Size Then
				Return c.Index
			Else
				Pos = PosMax
				c = Cache.Get(Pos)
			End If
			Exit
		End If
	Loop

	' Le meilleur candidat est entre l'index actuel (Pos) et l'index précédent (PosPrec)
	If Pos - PosPrec = 1 Then
		' Si l'index actuel rejoint l'index précédent, le meilleur candidat est l'un des deux.
		' On prend le deuxième s'il est dans la première moitié visible et si le précédent n'est
		' pas totalement visible.
		Dim cPrec As typCache
		cPrec = Cache.Get(PosPrec)
		If c.Top < Position + (getHeight / 2) AND cPrec.Top < Position Then
			Return c.Index
		Else
			Return cPrec.Index
		End If
	Else
		' Il y a encore un écart entre les index -> on refait un tour de piste
		Return FindInCache(Position, PosPrec, Floor((PosPrec + Pos) / 2), Pos)
	End If
End Sub
#End Region

'Replaces the scrollpanel background
'NewBackground = a valid bitmap or drawable
Public Sub ReplaceBackground(NewBackground As Object)
	If pnlDisplay.IsInitialized AND NewBackground <> Null Then
		lblDisplay.RemoveView
		If NewBackground Is Bitmap Then
			pnlDisplay.RemoveView     'We cannot do a SetLayout because of the default
			pnlDisplay.Initialize("") 'background padding so we reinitialize the panel
			Dim bmp As Bitmap
			bmp = NewBackground
			pnlRange.AddView(pnlDisplay, 0, 0, bmp.Width, bmp.Height)
			pnlDisplay.SetBackgroundImage(bmp)
		Else
			pnlDisplay.Background = NewBackground
		End If
		pnlDisplay.AddView(lblDisplay, 3dip, 3dip, pnlDisplay.Width - 6dip, pnlDisplay.Height - 6dip)
		MinPos = 0
		MaxPos = pnlRange.Height - pnlDisplay.Height
	End If
End Sub

'Gets the label inside the scrollpanel
Public Sub GetLabel As Label
	Return lblDisplay
End Sub

'Returns True if the user is dragging the ScrollPanel
Public Sub ScrollPanelMovedByUser As Boolean
	Return bUserMovingPnl
End Sub

'Removes the ScrollPanel
Public Sub Remove
	Anim.Stop(pnlDisplay)
	TimeOut.Enabled = False
	lblDisplay.RemoveView
	lblDisplay = Null
	pnlDisplay.RemoveView
	pnlDisplay = Null
	pnlRange.RemoveView
	pnlRange = Null
	CallbackShowHide = Null
	CallbackTextUpdated = Null
	Cache.Clear
End Sub
