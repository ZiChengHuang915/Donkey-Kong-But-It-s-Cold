Public Class Mainform
    'Library on Mount Char 
    'Corronzo
    'mood worsening
    'someone's head is going to roll

    Dim nStuff As SpriteType
    Dim gStuff As SpriteType
    Dim rnum As Integer

    Dim Ladder(NUMLADDERS) As PictureBox
    Const NUMLADDERS As Integer = 8
    Dim randomModifier As Integer = 100
    Dim randomModifier2 As Integer = 0
    Const NUMFLOORS As Integer = 6
    Dim fStuff(NUMFLOORS) As Floortype

    Dim Balls(NUMBALLS) As PictureBox
    Const NUMBALLS As Integer = 6
    Dim bStuff(NUMBALLS) As SpriteType

    Dim ThrowTimer As Integer
    Dim BobDancing As Boolean
    Dim EeepTimer As Integer
    Dim ExplosionTimer As Integer = 0

    Dim border As Double = 49

    Dim PelletDown As Integer
    Dim PelletLeft As Integer

    Dim PelletDown2 As Integer
    Dim PelletLeft2 As Integer

    Dim LaserTimer As Integer
    Dim blahtimer As Integer = 0
    Dim nextLaser As Integer
    Dim lasername As Integer = 1

    Dim hasPower As Boolean

    Dim missileTimer As Integer = 0
    Dim HeliSpeed As Double = 0.5

    Dim Pause As Boolean
    Dim Music As Integer

    Dim LevelNum As Integer = 1
    Dim Score As Integer = 0
    Dim ScoreTimer As Integer
    '23,44,54
   
    'KEYS
    'KEYS
    'KEYS

    Private Sub Mainform_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.P Then
            If Pause = False Then
                GameTimer.Stop()
                Pause1.Visible = True
                Pause2.Visible = True
                Pause = True
            Else
                GameTimer.Start()
                Pause1.Visible = False
                Pause2.Visible = False
                Pause = False
            End If
        End If
        If e.KeyCode = Keys.Q And hasPower = True Then
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\PowerUp.wav", AudioPlayMode.WaitToComplete)
            PowerUp()
            hasPower = False
            If Music = 1 Then
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\The Best Of Bach.wav", AudioPlayMode.BackgroundLoop)
            ElseIf Music = 2 Then
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Pirates.wav", AudioPlayMode.BackgroundLoop)
            ElseIf Music = 3 Then
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers.wav", AudioPlayMode.BackgroundLoop)
            ElseIf Music = 4 Then
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers_Voice.wav", AudioPlayMode.BackgroundLoop)
            Else
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\MissFortune_LoginScreenIntro.wav", AudioPlayMode.BackgroundLoop)
            End If
        End If
        If Hacks = True Then
            If e.KeyCode = Keys.F1 Then
                Nansen.Left = 445
                Nansen.Top = 60
            End If
            If e.KeyCode = Keys.F2 Then
                nSpeed = 6
            End If
            If e.KeyCode = Keys.F3 Then
                BallSpeed = 1
            End If
            If e.KeyCode = Keys.F12 Then
                nSpeed = 3
                BallSpeed = 4
            End If

            If e.KeyCode = Keys.D Then
                Explosion.Left = Nansen.Left
                Explosion.Top = Nansen.Top
                Explosion.Visible = True
                Nansen.Left = Nansen.Left + 100
            End If
            If e.KeyCode = Keys.A Then
                Explosion.Left = Nansen.Left
                Explosion.Top = Nansen.Top
                Explosion.Visible = True
                Nansen.Left = Nansen.Left - 100
            End If
            If e.KeyCode = Keys.Z Then
                Penguin.Left = 79
                Penguin.Top = 415
            End If
        End If
        If e.KeyCode = Keys.Space And nStuff.Speed.Y = 0 And nStuff.OnFloor = True Then
            nStuff.Speed.Y = -nSpeed
            nStuff.FloatTime = 0
            nStuff.Floating = True
            nStuff.OnFloor = False
        End If
        If e.KeyCode = Keys.Left Then
            If Nansen.Left > 77 Then
                nStuff.Speed.X = -nSpeed
            Else
                nStuff.Speed.X = 0
            End If
            nStuff.FacingRight = False
        End If
        If e.KeyCode = Keys.Right Then
            If Nansen.Left < 540 Then
                nStuff.Speed.X = nSpeed
            Else
                nStuff.Speed.X = 0
            End If
            nStuff.FacingRight = True
        End If
        If e.KeyCode = Keys.Up And nStuff.Floating = False Then
            nStuff.Speed.Y = -nSpeed
        End If
        If e.KeyCode = Keys.Down And nStuff.Floating = False Then
            nStuff.Speed.Y = nSpeed
        End If
    End Sub

    Private Sub Mainform_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            nStuff.Speed.X = 0
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If nStuff.Floating = False Then
                nStuff.Speed.Y = 0
            End If
        End If
    End Sub

    'MOVEMENT
    'MOVEMENT
    'MOVEMENT

    Private Sub moveGhost()
        gStuff.FloorNumber = GetFloorNumber(Ghost.Top)
        MoveAlongFloor(gStuff, Ghost)

        Randomize()
        Dim x = Int(Rnd() * 100)
        If x <= border Then
            If Ghost.Left > 77 Then
                Ghost.Left = Ghost.Left - GhostSpeed
            Else
                Explosion.Left = Ghost.Left
                Explosion.Top = Ghost.Top
                Explosion.Visible = True
                Ghost.Left = Ghost.Left + 220
            End If
            border = 97
        Else
            If Ghost.Left < 540 Then
                Ghost.Left = Ghost.Left + GhostSpeed
            Else
                Explosion.Left = Ghost.Left
                Explosion.Top = Ghost.Top
                Explosion.Visible = True
                Ghost.Left = Ghost.Left - 220
            End If
            border = 3
        End If

    End Sub

    Private Sub moveNansen()
        nStuff.FloorNumber = GetFloorNumber(Nansen.Top)
        If nStuff.Floating = True Then
            Jumping(nStuff)
        Else
            nStuff.OnLadder = OnLadder()
            If nStuff.OnLadder = False Then
                MoveAlongFloor(nStuff, Nansen)
            Else
                '  nStuff.Speed.X = 0
            End If
        End If
        If (Nansen.Left < 77 And nStuff.Speed.X < 0) Or (Nansen.Left > 540 And nStuff.Speed.X > 0) Then
            nStuff.Speed.X = 0
        End If

        Nansen.Left = Nansen.Left + nStuff.Speed.X
        Nansen.Top = Nansen.Top + nStuff.Speed.Y

    End Sub

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        If ScoreTimer > 9 Then
            Score = Score + 1
            ScoreTimer = 0
        Else
            ScoreTimer = ScoreTimer + 1
        End If
        ScoreLbl.Text = "Score: " + Score.ToString
        LevelLbl.Text = "Level: " + LevelNum.ToString
        If Nansen.Top < 0 Then
            Uplevel()
        End If
        If lasername = 0 Then
            Warn.Left = Warn.Left + 3
            lasername = 1
        ElseIf lasername = 1 Then
            Warn.Left = Warn.Left - 3
            lasername = 0
        End If
        If LevelNum = 1 Then
            moveGhost()
            Heli.Visible = False
            Rocket.Visible = False
            Smoke.Visible = False
            b1.Visible = False
            b2.Visible = False
            b3.Visible = False
            Pellet.Visible = False
            Pellet2.Visible = False
            Warn.Visible = False
            Laser.Visible = False
        ElseIf LevelNum = 2 Then
            movePellet()
            moveGhost()
            Pellet.Visible = True
           
        ElseIf LevelNum = 3 Then
            movePellet2()
            movePellet()
            moveGhost()
            Pellet2.Visible = True
        ElseIf LevelNum = 4 Then
            SmokeMove()
            RocketMove()
            movePellet2()
            movePellet()
            moveGhost()
            Rocket.Visible = True
            Smoke.Visible = True
        ElseIf LevelNum = 5 Then
            SmokeMove()
            MissileMove()
            MissileShoot()
            RocketMove()
            movePellet2()
            movePellet()
            moveGhost()
            Missile.Visible = True
        ElseIf LevelNum = 6 Then
            SmokeMove()
            HeliMove()
            MissileMove()
            MissileShoot()
            RocketMove()
            movePellet2()
            movePellet()
            moveGhost()
            Heli.Visible = True
        ElseIf LevelNum = 7 Then
            SmokeMove()
            FireBallMove()
            HeliMove()
            MissileMove()
            MissileShoot()
            RocketMove()
            movePellet2()
            movePellet()
            moveGhost()
            b1.Visible = True
            b2.Visible = True
            b3.Visible = True
        Else
            SmokeMove()
            FireBallMove()
            HeliMove()
            MissileMove()
            MissileShoot()
            RocketMove()
            movePellet2()
            movePellet()
            moveGhost()
            LaserMove()
            WarnMove()
            whatever()
            Warn.Visible = True
            Laser.Visible = True
        End If
        
        If ExplosionTimer > 20 Then
            Explosion.Visible = False
            ExplosionTimer = 0
        Else
            ExplosionTimer = ExplosionTimer + 1
        End If
        If Quit = True Then
            Me.Close()
        End If

        moveNansen()
        AnimateNansen()
        ThrowBall()
        AnimateBob()
        FlashHelp()
        whatever()
        If hasPower = True Then
            PowerIcon.Visible = True
        Else
            PowerIcon.Visible = False
        End If
        If Touching(Nansen, Power) = True Then
            Randomize()
            Dim place As Integer = Int(Rnd() * 5)
            If place = 0 Then
                Power.Left = 444
                Power.Top = 370
            ElseIf place = 1 Then
                Power.Left = 161
                Power.Top = 296
            ElseIf place = 2 Then
                Power.Left = 443
                Power.Top = 216
            ElseIf place = 3 Then
                Power.Left = 161
                Power.Top = 141
            ElseIf place = 4 Then
                Power.Left = 445
                Power.Top = 60
            End If
            hasPower = True
        End If
        If Touching(Nansen, Missile) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, Rocket) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, Laser) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Ghost, Nansen) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, Pellet) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        ElseIf Touching(Nansen, Pellet2) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, b1) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, b2) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        If Touching(Nansen, b3) = True Then
            GameTimer.Stop()
            YouDiedForm.ShowDialog()
            ResetLevel()
            GameTimer.Start()
        End If
        For Index = 0 To NUMBALLS
            If Balls(Index).Visible = True Then
                moveBall(Index)
                AnimateSnowball(Index)
                If Touching(Balls(Index), Nansen) = True Then
                    Dim nansenFloor = GetFloorNumber(Nansen.Top)
                    Dim blah = GetFloorNumber(Balls(Index).Top)
                    If GetFloorNumber(Nansen.Top) = GetFloorNumber(Balls(Index).Top) Then
                        GameTimer.Stop()
                        YouDiedForm.ShowDialog()
                        ResetLevel()
                        GameTimer.Start()
                    End If
                End If
            End If
        Next
        If Touching(Penguin, Nansen) = True Then
            Randomize()
            Dim place As Integer = Int(Rnd() * 5)
            If place = 0 Then
                Penguin.Left = 486
                Penguin.Top = 353
            ElseIf place = 1 Then
                Penguin.Left = 341
                Penguin.Top = 271
            ElseIf place = 2 Then
                Penguin.Left = 85
                Penguin.Top = 177
            ElseIf place = 3 Then
                Penguin.Left = 208
                Penguin.Top = 3
            ElseIf place = 4 Then
                Penguin.Left = 85
                Penguin.Top = 420
            End If
            Score = Score + 100 * LevelNum
        End If
        For Index = 0 To NUMBALLS
            If Brushing(Balls(Index), Nansen) Then
                Score = Score + 2 * LevelNum
            End If
        Next
        If Brushing(Missile, Nansen) Then
            Score = Score + 6 * LevelNum
        End If
        If Brushing(Rocket, Nansen) Then
            Score = Score + 7 * LevelNum
        End If
        If Brushing(Laser, Nansen) Then
            Score = Score + 1 * LevelNum
        End If
        If Brushing(Ghost, Nansen) Then
            Score = Score + 3 * LevelNum
        End If
        If Brushing(Pellet, Nansen) Then
            Score = Score + 4 * LevelNum
        End If
        If Brushing(Pellet2, Nansen) Then
            Score = Score + 5 * LevelNum
        End If
        If Brushing(b1, Nansen) Then
            Score = Score + 5 * LevelNum
        End If
        If Brushing(b2, Nansen) Then
            Score = Score + 5 * LevelNum
        End If
        If Brushing(b3, Nansen) Then
            Score = Score + 5 * LevelNum
        End If
    End Sub

    Private Sub moveBall(ByVal Index As Integer)

        bStuff(Index).FloorNumber = GetFloorNumber(Balls(Index).Top)
        If bStuff(Index).Floating = True Then
            Jumping(bStuff(Index))
        Else
            bStuff(Index).OnLadder = BallCheckLadder(Index)
            If bStuff(Index).OnLadder = False Then
                If fStuff(bStuff(Index).FloorNumber).slope < 0 Then
                    bStuff(Index).Speed.X = -BallSpeed
                Else
                    bStuff(Index).Speed.X = BallSpeed
                End If
                MoveAlongFloor(bStuff(Index), Balls(Index))
            Else
                bStuff(Index).Speed.X = 0
                bStuff(Index).Speed.Y = BallSpeed
                bStuff(Index).Floating = True
            End If
        End If
        If (Balls(Index).Left < 77 And bStuff(Index).Speed.X < 0 Or (Balls(Index).Left > 540 And bStuff(Index).Speed.X > 0)) Then
            bStuff(Index).Speed.X = 0
        End If

        Balls(Index).Left = Balls(Index).Left + bStuff(Index).Speed.X
        Balls(Index).Top = Balls(Index).Top + bStuff(Index).Speed.Y
        If bStuff(Index).FloorNumber = 0 And Balls(Index).Left < 88 Then
            Balls(Index).Visible = False
            If BobDancing = True Then
                BobDancing = False
                ThrowTimer = 0
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobStanding.jpg")
            End If
        End If
    End Sub

    'ANIMATION
    'ANIMATION
    'ANIMATION

    Private Sub AnimateNansen()

        If nStuff.Speed.Y <> 0 Then
            If nStuff.Floating = False Then
                AnimateClimb()
            Else
                AnimateJump()
            End If
        ElseIf nStuff.OnLadder = False Then
            If nStuff.Speed.X > 0 Then
                AnimateRight()
            ElseIf nStuff.Speed.X < 0 Then
                AnimateLeft()
            Else
                AnimateStanding()
            End If
        End If

    End Sub

    Private Sub AnimateSnowball(ByVal Index As Integer)
        If bStuff(Index).PicNum = 1 Then
            Balls(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball1.jpg")
            bStuff(Index).PicNum = 2
        ElseIf bStuff(Index).PicNum = 2 Then
            Balls(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball2.jpg")
            bStuff(Index).PicNum = 3
        ElseIf bStuff(Index).PicNum = 3 Then
            Balls(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball3.jpg")
            bStuff(Index).PicNum = 4
        ElseIf bStuff(Index).PicNum = 4 Then
            Balls(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball4.jpg")
            bStuff(Index).PicNum = 1
        End If
    End Sub

    Private Sub AnimateStanding()

        If nStuff.FacingRight Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove1.jpg")
        Else
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenleftMove1.jpg")
        End If

    End Sub

    Private Sub AnimateJump()

        If nStuff.Speed.X > 0 And nStuff.FacingRight = True Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenRightFloat.jpg")
        Else
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenLeftFloat.jpg")
        End If

    End Sub

    Private Sub AnimateRight()

        If nStuff.PicNum = 1 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove2.jpg")
            nStuff.PicNum = 2
        ElseIf nStuff.PicNum = 2 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove3.jpg")
            nStuff.PicNum = 3
        ElseIf nStuff.PicNum = 3 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove1.jpg")
            nStuff.PicNum = 1
        End If

    End Sub

    Private Sub AnimateLeft()

        If nStuff.PicNum = 1 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenleftMove2.jpg")
            nStuff.PicNum = 2
        ElseIf nStuff.PicNum = 2 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenleftMove3.jpg")
            nStuff.PicNum = 3
        ElseIf nStuff.PicNum = 3 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenleftMove1.jpg")
            nStuff.PicNum = 1
        End If

    End Sub

    Private Sub AnimateClimb()

        If nStuff.PicNum = 1 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenClimb2.jpg")
            nStuff.PicNum = 2
        ElseIf nStuff.PicNum = 2 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenClimb3.jpg")
            nStuff.PicNum = 3
        ElseIf nStuff.PicNum = 3 Then
            Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenClimb1.jpg")
            nStuff.PicNum = 1
        End If

    End Sub

    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles Me.Load

        Randomize()
        Dim value As Integer = CInt(Rnd() * 5)
        If value = 1 Then
            Music = 1
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\The Best Of Bach.wav", AudioPlayMode.BackgroundLoop)
        ElseIf value = 2 Then
            Music = 2
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Pirates.wav", AudioPlayMode.BackgroundLoop)
        ElseIf value = 3 Then
            Music = 3
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers.wav", AudioPlayMode.BackgroundLoop)
        ElseIf value = 4 Then
            Music = 4
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers_Voice.wav", AudioPlayMode.BackgroundLoop)
        Else
            Music = 5
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\MissFortune_LoginScreenIntro.wav", AudioPlayMode.BackgroundLoop)
        End If
        If Music = 3 Or Music = 4 Then
            '  Optimus.Visible = True
        Else
            Optimus.Visible = False
        End If
        Quit = False
        ResetLevel()
        Explosion.Visible = False
        PowerIcon.Visible = False
        Pause1.Visible = False
        Pause2.Visible = False
    End Sub

    'LADDER
    'LADDER
    'LADDER

    Private Function OnLadder()
        'Look At This Next Week!!!
        Dim LadderOffset As Integer = 15

        For Index = 0 To NUMLADDERS
            If nStuff.Speed.Y < 0 Then
                'Nansen is going down
                If Nansen.Left > Ladder(Index).Left - LadderOffset And Nansen.Right < Ladder(Index).Right + LadderOffset Then
                    If Nansen.Top < Ladder(Index).Bottom And Nansen.Bottom > Ladder(Index).Top Then
                        Return True
                    End If
                End If
            ElseIf nStuff.Speed.Y > 0 Then
                'Nansen is going up
                If Nansen.Left > Ladder(Index).Left - LadderOffset And Nansen.Right < Ladder(Index).Right + LadderOffset Then
                    If Nansen.Top < Ladder(Index).Bottom And Nansen.Bottom > Ladder(Index).Top - LadderOffset Then
                        Return True
                    End If
                End If

            ElseIf nStuff.Speed.Y = 0 Then
                'Nansen is not moving
                If Nansen.Left > Ladder(Index).Left - LadderOffset And Nansen.Right < Ladder(Index).Right + LadderOffset Then
                    If Nansen.Top < Ladder(Index).Bottom - LadderOffset And Nansen.Bottom > Ladder(Index).Top + LadderOffset Then
                        Return True
                    End If
                End If
            End If
        Next

        Return False
    End Function

    'FLOORS
    'FLOORS
    'FLOORS

    Public Sub FloorSet()
        fStuff(6).slope = 0
        fStuff(5).slope = 0
        fStuff(4).slope = -0.078
        fStuff(3).slope = 0.078
        fStuff(2).slope = -0.078
        fStuff(1).slope = 0.078
        fStuff(0).slope = -0.001

        fStuff(0).x = 137
        fStuff(0).y = 465
        fStuff(0).leftedge = 0
        fStuff(0).rightedge = 570

        fStuff(1).x = 137
        fStuff(1).y = 377
        fStuff(1).leftedge = 0
        fStuff(1).rightedge = 507

        fStuff(2).x = 137
        fStuff(2).y = 327
        fStuff(2).leftedge = 133
        fStuff(2).rightedge = 570

        fStuff(3).x = 137
        fStuff(3).y = 226
        fStuff(3).leftedge = 0
        fStuff(3).rightedge = 507

        fStuff(4).x = 137
        fStuff(4).y = 176
        fStuff(4).leftedge = 133
        fStuff(4).rightedge = 570

        fStuff(5).x = 137
        fStuff(5).y = 92
        fStuff(5).leftedge = 0
        fStuff(5).rightedge = 507

        fStuff(6).x = 137
        fStuff(6).y = 42
        fStuff(6).leftedge = 200
        fStuff(6).rightedge = 312
    End Sub

    Private Function GetFloorNumber(ByVal ThingTop As Integer)

        If ThingTop < 25 Then
            Return 6
        ElseIf ThingTop < 75 Then
            Return 5
        ElseIf ThingTop < 165 Then
            Return 4
        ElseIf ThingTop < 245 Then
            Return 3
        ElseIf ThingTop < 325 Then
            Return 2
        ElseIf ThingTop < 398 Then
            Return 1
        End If
        Return 0

    End Function

    'SNOWBALLS
    'SNOWBALLS
    'SNOWBALLS

    Private Sub ThrowBall()
        Dim Done As Boolean
        Dim Index As Integer

        Dim Index2 As Integer

        ThrowTimer = ThrowTimer + 1
        If ThrowTimer = TimeToGo Then
            ThrowTimer = 0
            Done = False
            Do While Done = False
                If Balls(Index).Visible = False Then
                    Done = True
                    Balls(Index).Visible = True
                    Balls(Index).Top = 70
                    Balls(Index).Left = 203
                    bStuff(Index).Floating = False
                    bStuff(Index).OnLadder = False
                    bStuff(Index).PicNum = 1
                    bStuff(Index).Speed.X = 10
                    bStuff(Index).Speed.Y = 0
                    BobDancing = True
                    For Index2 = 0 To 3
                        If Balls(Index2).Visible = False Then
                            BobDancing = False
                        End If
                    Next Index2
                End If

                Index = Index + 1
                If Index = NUMBALLS + 1 Then
                    Done = True
                End If
            Loop

        End If

    End Sub

    Private Function BallCheckLadder(ByVal Index As Integer)
        Dim LadderIndex As Integer
        Dim BallLadderOffset As Integer
        BallLadderOffset = 13
        Randomize()
        rnum = Int(Rnd() * 5)
        If rnum = 0 Then
            For LadderIndex = 0 To NUMLADDERS
                If Balls(Index).Left > Ladder(LadderIndex).Left And Balls(Index).Right < Ladder(LadderIndex).Right Then
                    If Balls(Index).Bottom + BallLadderOffset > Ladder(LadderIndex).Top And Balls(Index).Bottom - BallLadderOffset < Ladder(LadderIndex).Top Then
                        Return True
                    End If
                End If
            Next LadderIndex
        End If
        Return False
    End Function

    'CLEANING
    'CLEANING
    'CLEANING

    Private Sub Jumping(ByRef sprite As SpriteType)
        If sprite.FloatTime = JumpHeight Then

            If sprite.Speed.Y = -nSpeed Then
                sprite.Speed.Y = nSpeed
            Else
                sprite.Speed.Y = 0
                sprite.Floating = False
            End If
            sprite.FloatTime = 1
        Else
            sprite.FloatTime = sprite.FloatTime + 1
        End If
    End Sub

    Private Sub MoveAlongFloor(ByRef sprite As SpriteType, ByRef Thing As PictureBox)
        sprite.Speed.Y = 0
        sprite.OnFloor = True
        '''''''''''''''''''''''''''''slope*run 
        Thing.Top = fStuff(sprite.FloorNumber).slope * (Thing.Left - fStuff(sprite.FloorNumber).x) + fStuff(sprite.FloorNumber).y - Thing.Height
        '''''''''''''''''''''''''''''
        If Thing.Left > fStuff(sprite.FloorNumber).rightedge Then
            sprite.Floating = True
            sprite.FloatTime = 1
            sprite.Speed.Y = 5
        ElseIf Thing.Left + Thing.Width < fStuff(sprite.FloorNumber).leftedge Then
            sprite.Floating = True
            sprite.FloatTime = 1
            sprite.Speed.Y = 5
        End If
    End Sub

    Private Function Touching(ByVal Object1 As PictureBox, ByVal Object2 As PictureBox)
        If Object1.Right > Object2.Left And Object1.Left < Object2.Right Then
            If Object1.Bottom > Object2.Top And Object1.Top < Object2.Bottom Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Sub ResetLevel()
        BobDancing = False
        PenguinSet()
        NansenSet()
        BallSet()
        LadderSet()
        FloorSet()
        PelletSet()
        LaserSet()
        RocketSet()
        FireSet()
        IconSet()
        heliMissileSet()
        Ladder8.Left = 365
        Ladder8.Top = -32
        Score = 0
        LevelNum = 1
        LevelLbl.Text = "Level: " + LevelNum.ToString
    End Sub

    Public Sub Uplevel()
        My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\RollOut.wav", AudioPlayMode.WaitToComplete)

        If Music = 1 Then
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\The Best Of Bach.wav", AudioPlayMode.BackgroundLoop)
        ElseIf Music = 2 Then
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Pirates.wav", AudioPlayMode.BackgroundLoop)
        ElseIf Music = 3 Then
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers.wav", AudioPlayMode.BackgroundLoop)
        ElseIf Music = 4 Then
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\Transformers_Voice.wav", AudioPlayMode.BackgroundLoop)
        Else
            My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Sounds\MissFortune_LoginScreenIntro.wav", AudioPlayMode.BackgroundLoop)
        End If
        Ladder7.Left = 365
        Ladder7.Top = -32
        Ladder8.Left = 150
        Ladder8.Top = 459
        BobDancing = False
        LevelNum = LevelNum + 1
        LevelLbl.Text = "Level: " + LevelNum.ToString
        BallSet()
        LadderSet()
        FloorSet()
        PelletSet()
        LaserSet()
        RocketSet()
        FireSet()
        IconSet()
        heliMissileSet()
        UpNansenSet()
        PenguinSet()
    End Sub

    Private Sub PenguinSet()
        Randomize()
        Dim place As Integer = Int(Rnd() * 5)
        If place = 0 Then
            Penguin.Left = 486
            Penguin.Top = 353
        ElseIf place = 1 Then
            Penguin.Left = 341
            Penguin.Top = 271
        ElseIf place = 2 Then
            Penguin.Left = 85
            Penguin.Top = 177
        ElseIf place = 3 Then
            Penguin.Left = 208
            Penguin.Top = 3
        ElseIf place = 4 Then
            Penguin.Left = 85
            Penguin.Top = 420
        End If
    End Sub

    Private Sub NansenSet()
        nStuff.PicNum = 1
        nStuff.FacingRight = True
        Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove1.jpg")
        Nansen.Left = 104
        Nansen.Top = 430
        nStuff.Speed.X = 0
        nStuff.Speed.Y = 0
        nStuff.OnFloor = True
    End Sub

    Private Sub UpNansenSet()
        nStuff.PicNum = 1
        nStuff.FacingRight = True
        Nansen.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\NansenrightMove1.jpg")
        nStuff.Speed.X = 0
        nStuff.Speed.Y = 0
        nStuff.OnLadder = True
        Nansen.Left = 145
        Nansen.Top = 483
    End Sub

    Private Sub BallSet()
        nStuff.PicNum = 1
        Balls(0) = ball0
        Balls(1) = ball1
        Balls(2) = ball2
        Balls(3) = ball3
        Balls(4) = ball4
        Balls(5) = ball5
        Balls(6) = ball6

        For index = 0 To 6
            Balls(index).Top = 70
            Balls(index).Left = 203
            Balls(index).Visible = False
            bStuff(index).Floating = False
            bStuff(index).OnLadder = False
            bStuff(index).PicNum = 1
            bStuff(index).Speed.X = BallSpeed
            bStuff(index).Speed.Y = 0


        Next

    End Sub

    Private Sub LadderSet()
        Ladder(0) = Ladder0
        Ladder(1) = Ladder1
        Ladder(2) = Ladder2
        Ladder(3) = Ladder3
        Ladder(4) = Ladder4
        Ladder(5) = Ladder5
        Ladder(6) = Ladder6
        Ladder(7) = Ladder7
        Ladder(8) = Ladder8
        FloorSet()

        BallSet()
    End Sub

    Private Sub PelletSet()
        Pellet.Left = 630
        Pellet.Top = 0
        Pellet2.Left = 0
        Pellet2.Left = 0
    End Sub

    Private Sub LaserSet()
        Laser.Left = 0
        Warn.Left = 0
    End Sub

    Private Sub RocketSet()
        Rocket.Top = 100
        Rocket.Left = 631
    End Sub

    Private Sub FireSet()
        b1.Top = 0
        b1.Left = 300
        b2.Top = 0
        b2.Left = 300
        b3.Top = 0
        b3.Left = 300
    End Sub

    Private Sub IconSet()
        Randomize()
        Dim place As Integer = Int(Rnd() * 5)
        If place = 0 Then
            Power.Left = 444
            Power.Top = 370
        ElseIf place = 1 Then
            Power.Left = 161
            Power.Top = 296
        ElseIf place = 2 Then
            Power.Left = 443
            Power.Top = 216
        ElseIf place = 3 Then
            Power.Left = 161
            Power.Top = 141
        ElseIf place = 4 Then
            Power.Left = 445
            Power.Top = 60
        End If
        hasPower = False
        PowerIcon.Visible = False
    End Sub

    Private Sub heliMissileSet()
        Heli.Left = 583
        Heli.Top = 420
        missileTimer = 0
        Missile.Left = -100
    End Sub

    Private Sub PowerUp()
        Warn.Left = 0
        Laser.Left = 0
        Rocket.Left = -300
        b1.Top = -5000
        Pellet.Left = 1130
        Pellet.Top = -500
        Pellet2.Left = -500
        Pellet2.Left = -500
        missileTimer = 0
        Heli.Top = 0
    End Sub

    Private Sub FlashHelp()
        If Eeep.Visible = True And EeepTimer > 30 Then
            Eeep.Visible = False
            EeepTimer = 0
        ElseIf Eeep.Visible = False And EeepTimer > 30 Then
            Eeep.Visible = True
            EeepTimer = 0
        Else
            EeepTimer = EeepTimer + 1
        End If
    End Sub

    'BOB
    'BOB
    'BOB

    Private Sub AnimateBob()
        If BobDancing = False Then
            If ThrowTimer > 190 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobRollingBall.jpg")
            ElseIf ThrowTimer > 170 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobholdingBall.jpg")
            ElseIf ThrowTimer > 150 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobGettingBall.jpg")
            End If
        Else
            If ThrowTimer > 30 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobSmiling.jpg")
            ElseIf ThrowTimer > 22 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobDancing2.jpg")
            ElseIf ThrowTimer > 14 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobDancing.jpg")
            ElseIf ThrowTimer > 8 Then
                Bob.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobStanding.jpg")
            End If
        End If
    End Sub

    Private Sub movePellet()
        Randomize()
        Dim a = Int(Rnd() * 5)
        If a = 0 Then
            PelletDown = 1
        ElseIf a = 1 Then
            PelletDown = 2
        ElseIf a = 2 Then
            PelletDown = 3
        ElseIf a = 3 Then
            PelletDown = 0
        Else
            PelletDown = 5
        End If
        Randomize()
        Dim b = Int(Rnd() * 5)
        If b = 0 Then
            PelletLeft = 2
        ElseIf b = 1 Then
            PelletLeft = 2
        ElseIf b = 2 Then
            PelletLeft = 3
        ElseIf b = 3 Then
            PelletLeft = 0
        Else
            PelletLeft = 5
        End If
        Pellet.Top = Pellet.Top + PelletDown
        Pellet.Left = Pellet.Left - PelletLeft
        If Pellet.Top > 470 Or Pellet.Left < 0 Then
            Pellet.Top = 0
            Pellet.Left = 630
        End If
    End Sub

    Private Sub movePellet2()
        Randomize()
        Dim a = Int(Rnd() * 5)
        If a = 0 Then
            PelletDown2 = 1
        ElseIf a = 1 Then
            PelletDown2 = 2
        ElseIf a = 2 Then
            PelletDown2 = 3
        ElseIf a = 3 Then
            PelletDown2 = 0
        Else
            PelletDown2 = 5
        End If
        Randomize()
        Dim b = Int(Rnd() * 5)
        If b = 0 Then
            PelletLeft2 = 2
        ElseIf b = 1 Then
            PelletLeft2 = 2
        ElseIf b = 2 Then
            PelletLeft2 = 3
        ElseIf b = 3 Then
            PelletLeft2 = 0
        Else
            PelletLeft2 = 5
        End If
        Pellet2.Top = Pellet2.Top + PelletDown2
        Pellet2.Left = Pellet2.Left + PelletLeft2
        If Pellet2.Top > 470 Or Pellet2.Left < 0 Then
            Pellet2.Top = 0
            Pellet2.Left = 0
        End If
    End Sub

    Private Sub WarnMove()
        If LaserTimer > 200 Then
            Randomize()
            Dim a = Int(Rnd() * 631)
            Warn.Left = a
            LaserTimer = 0
            blahtimer = 0
        Else
            LaserTimer = LaserTimer + 1
        End If
    End Sub

    Private Sub whatever()
        If blahtimer <> -1 Then
            blahtimer = blahtimer + 1
            If blahtimer > 100 Then
                LaserMove()
                blahtimer = -1
            End If
        End If
    End Sub

    Private Sub LaserMove()
        If blahtimer > 100 Then
            Laser.Left = Warn.Left
        End If
    End Sub

    Private Sub RocketMove()
        If Rocket.Left > -2000 Then
            Rocket.Left = Rocket.Left - 5
        Else
            Randomize()
            Dim b As Integer = CInt(Rnd() * 420)
            Rocket.Top = b
            Rocket.Left = 631
        End If
    End Sub

    Private Sub SmokeMove()
        Smoke.Top = Rocket.Top + 16
        Smoke.Left = Rocket.Left + 70
    End Sub

    Private Sub FireBallMove()
        If b1.Top < 2000 Then
            b1.Top = b1.Top + 8
        Else
            b1.Top = -10
            Randomize()
            Dim a As Integer = CInt(Rnd() * 600)
            b1.Left = a
        End If
        b2.Top = b1.Top - 70
        b3.Top = b2.Top - 70

        b2.Left = b1.Left
        b3.Left = b1.Left
    End Sub

    Private Sub HeliMove()
        If Heli.Top < Nansen.Top Then
            Heli.Top = Heli.Top + 1
        ElseIf Heli.Top > Nansen.Top Then
            Heli.Top = Heli.Top - 1
        Else
        End If
    End Sub

    Private Sub MissileShoot()
        If missileTimer > 500 Then
            Missile.Left = Heli.Left
            Missile.Top = Heli.Top + 15
            missileTimer = 0
        Else
            missileTimer = missileTimer + 1
        End If
    End Sub

    Private Sub MissileMove()
        If Missile.Left < -100 Then
        Else
            Missile.Left = Missile.Left - 3
        End If
    End Sub

    Private Function Brushing(ByVal Object1 As PictureBox, ByVal Object2 As PictureBox)
        Dim object1radius As Integer = (Object1.Right - Object1.Left) / 2
        Dim object2radius As Integer = (Object2.Right - Object2.Left) / 2

        Dim object1xcenter As Integer = Object1.Left + object1radius
        Dim object2xcenter As Integer = Object2.Left + object2radius

        Dim object1ycenter As Integer = (Object1.Top + Object1.Bottom) / 2
        Dim object2ycenter As Integer = (Object2.Top + Object2.Bottom) / 2

        Dim distancex As Double = object2xcenter - object1xcenter
        Dim distancey As Double = object2ycenter - object1ycenter
        ''Orange is the a2 +  b2
        Dim orange As Double = Math.Sqrt(distancex * distancex + distancey * distancey)


        ''C is the actual distance between the two
        Dim c As Double = Math.Sqrt((object1radius + object2radius) * (object1radius + object2radius))

        Dim distance = orange - c
        If distance > 0 And distance < 30 Then
            Return True
        End If
        Return False
    End Function
End Class
