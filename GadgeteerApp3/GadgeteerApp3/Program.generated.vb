'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.34014
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports Gadgeteer
Imports GTM = Gadgeteer.Modules

Namespace GadgeteerApp3
    
    Partial Public Class Program
        Inherits Gadgeteer.Program
        
        '''<summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        Protected Shadows Shared Property Mainboard() As GHIElectronics.Gadgeteer.FEZCerbuinoBee
            Get
                Return CType(Gadgeteer.Program.Mainboard,GHIElectronics.Gadgeteer.FEZCerbuinoBee)
            End Get
            Set
                Gadgeteer.Program.Mainboard = value
            End Set
        End Property
        
        '''<summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        Public Shared Sub Main()
            'Important to initialize the Mainboard first
            Program.Mainboard = New GHIElectronics.Gadgeteer.FEZCerbuinoBee()
            Dim p As Program = New Program()
            p.InitializeModules
            p.ProgramStarted
            'Starts Dispatcher
            p.Run
        End Sub
        
        Private Sub InitializeModules()
        End Sub
    End Class
End Namespace
