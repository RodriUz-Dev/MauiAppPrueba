Aplicación Móvil Básico en .NET MAUI
MauiAppPrueba
Aplicación móvil básica desarrollada en .NET MAUI con las siguientes características

1.	Se crea el proyecto MauiAppPrueba con .NET MAUI, con el Framework .NET 9.0
2.	Se instala el nuget de CommunityToolkit.Mvvm 8.4.0 para el manejo de los cambios de estado de los campos  con [ObservableProperty] y la implementación de [RelayCommand] para el manejo de comandos MVVM y para mejorar el rendimientos en el tiempo de ejecución y mejorar la comprensión del código.
 
3.	Se crean las vistas principales de la aplicación con sus funcionalidades de navegación:
a.	LoginView
b.	CreateAccountView
c.	EmployeesView
d.  EditEmployeeView

5.	Se crea la carpeta ViewModels para incluir el código de los ViewModels para cada funcionalidad de la aplicación
6.	Se agregan los recursos de: 
a.	FontAwesomeSolid para incluir iconos a la aplicación
b.	Los fonts de la familia Lato para la tipografía de la aplicación
c.	Imágenes para incluirlas en el diseño de la aplicación

7.	Se crea el repositorio en github para el control de cambios del código del proyecto, así como la rama master y la rama dev para realizar los cambios en esta rama hija y posteriormente hacer el PR a la rama master.

8.	Se agregan al proyecto las capas que conforman la arquitectura limpia y las referencias entre proyectos
a)	Capa de Dominio: MauiAppPrueba.Domain
b)	Capa de Aplicación: MauiAppPrueba.Application
c)	Capa de Infraestructura: MauiAppPrueba.Infrastructure
d)	Capa de Presentación: MauiAppPrueba.API
e)	Capa de Interfaz de Usuario: MauiAppPrueba

9.	 Se instalan los nugets de Microsoft.EntityFrameworkCore para el manejo de migraciones a la base de datos
a.	Microsoft.EntityFrameworkCore Ver 9.0.3
b.	Microsoft.EntityFrameworkCore.Tools Ver 9.0.3
c.	Microsoft.EntityFrameworkCore.Sqlite Ver 9.0.3

10.	Se ejecuta la migración de la base de datos con EntityFramework y MS SQL Server
11.	Se asignan los permisos para utilizar biometric y fingerprint
 
12.	Se instalan los nugets de Plugin.Maui.Biometric,  Plugin.FingerPrint y de Xamarin.AndroidX.Migration para la funcionalidad de inicio de sesión con biometria

14.	Registrar aplicación Azure AD B2C para la Autenticación mediante OAuth 2.0 usando MSAL  MsalAuthDevUz
