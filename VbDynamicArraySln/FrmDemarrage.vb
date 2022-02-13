Imports VbDynamicArray.Tableau

Public Class FrmDemarrage
    Dim monTab As New Tableau(10)

#Region "Form"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To gbZoneAffichage.Controls.Count - 1
            gbZoneAffichage.Controls(i).Text = i
        Next

        DonnéesToolStripMenuItem.Enabled = False
        TrierToolStripMenuItem.Enabled = False
        RechercherToolStripMenuItem.Enabled = False
        PermuterToolStripMenuItem.Enabled = False
        AideStripMenuItem.Enabled = False

    End Sub

    Public Sub refreshZoneAffichage()
        Dim i As Integer
        For i = 0 To gbZoneAffichage.Controls.Count - 1
            gbZoneAffichage.Controls(i).Text = monTab.GetValeur(tbDecalage.Value + i)
        Next
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnQuitter.Click
        If MessageBox.Show("Voulez-vous fermer ?", "Fermeture", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

#End Region

#Region "Tab Fichier"
    Private Sub TableauToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TableauToolStripMenuItem.Click
        Dim nb As Object
        nb = Interaction.InputBox("Entrer le nombre d'éléments du tableau svp :")

        If (IsNumeric(nb) = False) Then
            MessageBox.Show("Impossible de définir un  tableau veuillez renseigner un entier.", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (nb < 10) Then
            MessageBox.Show("Imposible de définir un tableau d'une taille inférieur à 10.", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            monTab.SetNbElt(nb - 1)
            monTab.InitTab(0)
            tbDecalage.Minimum = 0
            tbDecalage.Maximum = nb - 10
            refreshZoneAffichage()

            DonnéesToolStripMenuItem.Enabled = True
            TrierToolStripMenuItem.Enabled = True
            RechercherToolStripMenuItem.Enabled = True
            PermuterToolStripMenuItem.Enabled = True
            AideStripMenuItem.Enabled = True
            tbDecalage.Enabled = True
        End If
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub tbDecalage_Scroll(sender As Object, e As EventArgs) Handles tbDecalage.Scroll
        refreshZoneAffichage()
    End Sub

#End Region

#Region "Tab Données"
    Private Sub InitialiserÀNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitialiserÀNToolStripMenuItem.Click
        Dim nb As Integer
        nb = Interaction.InputBox("Entrer une valeur d'initialisation :")
        monTab.InitTab(nb)
        refreshZoneAffichage()
    End Sub

    Private Sub InitialiserÀZéroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitialiserÀZéroToolStripMenuItem.Click
        monTab.InitTab(0)
        refreshZoneAffichage()
    End Sub

    Private Sub InitialisationAléatoireToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitialisationAléatoireToolStripMenuItem.Click
        monTab.InitAleatoire()
        refreshZoneAffichage()
    End Sub

    Private Sub InitialiserSéquentielleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitialiserSéquentielleToolStripMenuItem.Click
        monTab.InitSequentiel()
        refreshZoneAffichage()
    End Sub

#End Region

#Region "Tab Rechercher"
    Private Sub ValeurPetitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValeurPetitToolStripMenuItem.Click
        MessageBox.Show("La plus petite valeur du tableau est : " + Convert.ToString(monTab.PlusPetitDeTab()))
    End Sub

    Private Sub ValeurGrandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValeurGrandToolStripMenuItem.Click
        MessageBox.Show("La plus grande valeur du tableau est : " + Convert.ToString(monTab.PlusGrandDeTab()))
    End Sub

    Private Sub IndicePetitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndicePetitToolStripMenuItem.Click
        MessageBox.Show("L'indice de la plus petite valeur du tableau est : " + Convert.ToString(monTab.PlusPetitIndiceDeTab()))
    End Sub

    Private Sub IndiceGrandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndiceGrandToolStripMenuItem.Click
        MessageBox.Show("L'indice de la plus grande valeur du tableau est : " + Convert.ToString(monTab.PlusGrandIndiceDeTab()))
    End Sub

    Private Sub IndicePetitDepuisPosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndicePetitDepuisPosToolStripMenuItem.Click
        Dim nb As Integer = Interaction.InputBox("Veuillez renseigner la position")
        Dim indPetit As Integer = monTab.PlusPetitIndiceDeTabDepuisPos(nb)
        MessageBox.Show("L'indice de la plus petite valeur du tableau à partir de " + Convert.ToString(nb) + " est : " + Convert.ToString(indPetit))
    End Sub

#End Region

#Region "Tab Trier"
    Private Sub TriÀBullesCroissantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriÀBullesCroissantToolStripMenuItem.Click
        monTab.TriABullesCroissant()
        refreshZoneAffichage()
    End Sub

    Private Sub TriÀBullesDécroissantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriÀBullesDécroissantToolStripMenuItem.Click
        monTab.TriABullesDecroissant()
        refreshZoneAffichage()
    End Sub

    Private Sub TriParSelectionCroissantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriParSelectionCroissantToolStripMenuItem.Click
        monTab.TriParSelectionCroissant()
        refreshZoneAffichage()
    End Sub

    Private Sub TriParSéletionDécroissantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriParSéletionDécroissantToolStripMenuItem.Click
        monTab.TriParSelectionDecroissant()
        refreshZoneAffichage()
    End Sub

    Private Sub TableauTrierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableauTrierToolStripMenuItem.Click
        Select Case monTab.estTrie()
            Case -1
                MessageBox.Show("Le tableau actuel n'est pas trié.")
            Case 0
                MessageBox.Show("Le tableau actuel à toutes ces valeurs égales.")
            Case 1
                MessageBox.Show("Le tableau actuel est trié par odre croissant.")
            Case 2
                MessageBox.Show("Le tableau actuel est trié par odre décroissant.")
        End Select
    End Sub

#End Region

#Region "Tab Permuter"

    Private Sub InsérerValeurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsérerValeurToolStripMenuItem.Click
        Dim nb As Integer = Interaction.InputBox("Entrer la valeur à insérer dans le tableau :")
        monTab.InsererValeur(nb)
        ' Regarde si le la longeur du tableau est pair ou non.
        If (monTab.GetNbElt() \ 2 = 0) Then
            tbDecalage.Maximum = monTab.GetNbElt() - 10
        Else
            tbDecalage.Maximum = (monTab.GetNbElt() - 10) + 1
        End If
        refreshZoneAffichage()
    End Sub

    Private Sub InverserTableauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InverserTableauToolStripMenuItem.Click
        monTab.InverserTab()
        refreshZoneAffichage()
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click
        Dim nb As Integer = Interaction.InputBox("Veuillez renseigner la position")
        monTab.SupprimerDansTab(nb)
        If (monTab.GetNbElt() \ 2 = 0) Then
            tbDecalage.Maximum = monTab.GetNbElt() - 10
        Else
            tbDecalage.Maximum = (monTab.GetNbElt() - 10) + 1
        End If
        refreshZoneAffichage()
    End Sub

#End Region

#Region "Tab ?"
    Private Sub AideStripMenuItem_Click(sender As Object, e As EventArgs) Handles AideStripMenuItem.Click
        MessageBox.Show("Développer par Ahmosys - Licence MIT " & DateTime.Now.Year.ToString() & vbCrLf & "https://github.com/Ahmosys")
    End Sub

#End Region

End Class
