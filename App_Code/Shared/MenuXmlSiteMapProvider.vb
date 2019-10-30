Imports System
Imports System.Web
Imports BaseClasses.Utils
Imports BaseClasses.Configuration

Namespace IROC2.UI

	''' <summary>
	''' Summary description for MenuXmlSiteMapProvider
	''' This integrates site map provider with role based security.
	''' </summary>
	Public Class MenuXmlSiteMapProvider 
		Inherits XmlSiteMapProvider
		
	   

	    ' Check the logged in user against the role asigned for the current menu.
	    ' Returns true if logged user belongs to the role. If not then false is returned.
        Public Overrides Function IsAccessibleToUser(ByVal context As HttpContext, ByVal node As SiteMapNode) As Boolean
            If BaseClasses.Configuration.ApplicationSettings.Current.SecurityDisabled Then
                Return True
            Else
                If (node.Roles.Count = 0) Then
                    Return True
                Else
                    Return BaseClasses.Utils.SecurityControls.IsUserInRole(context, node.Roles)
                End If
            End If
        End Function
	End Class
End Namespace
