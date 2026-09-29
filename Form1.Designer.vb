<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnExportarCatalogo = New System.Windows.Forms.Button()
        Me.TxtArchivo = New System.Windows.Forms.TextBox()
        Me.LblNameArchivo = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Location = New System.Drawing.Point(565, 9)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(125, 67)
        Me.BtnLimpiar.TabIndex = 0
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'BtnCargar
        '
        Me.BtnCargar.Location = New System.Drawing.Point(434, 9)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(125, 67)
        Me.BtnCargar.TabIndex = 1
        Me.BtnCargar.Text = "Cargar datos"
        Me.BtnCargar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(696, 9)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(125, 67)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Guardar datos"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnExportarCatalogo
        '
        Me.BtnExportarCatalogo.Location = New System.Drawing.Point(827, 9)
        Me.BtnExportarCatalogo.Name = "BtnExportarCatalogo"
        Me.BtnExportarCatalogo.Size = New System.Drawing.Size(125, 67)
        Me.BtnExportarCatalogo.TabIndex = 3
        Me.BtnExportarCatalogo.Text = "Exportar catalogos"
        Me.BtnExportarCatalogo.UseVisualStyleBackColor = True
        '
        'TxtArchivo
        '
        Me.TxtArchivo.Location = New System.Drawing.Point(28, 32)
        Me.TxtArchivo.Name = "TxtArchivo"
        Me.TxtArchivo.Size = New System.Drawing.Size(400, 26)
        Me.TxtArchivo.TabIndex = 4
        '
        'LblNameArchivo
        '
        Me.LblNameArchivo.AutoSize = True
        Me.LblNameArchivo.Location = New System.Drawing.Point(24, 9)
        Me.LblNameArchivo.Name = "LblNameArchivo"
        Me.LblNameArchivo.Size = New System.Drawing.Size(144, 20)
        Me.LblNameArchivo.TabIndex = 5
        Me.LblNameArchivo.Text = "Nombre del archivo"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1306, 303)
        Me.DataGridView1.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1365, 505)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LblNameArchivo)
        Me.Controls.Add(Me.TxtArchivo)
        Me.Controls.Add(Me.BtnExportarCatalogo)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCargar)
        Me.Controls.Add(Me.BtnLimpiar)
        Me.Name = "Form1"
        Me.Text = "Carga de catálogos de canales - CONTOSO"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents BtnCargar As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnExportarCatalogo As Button
    Friend WithEvents TxtArchivo As TextBox
    Friend WithEvents LblNameArchivo As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
