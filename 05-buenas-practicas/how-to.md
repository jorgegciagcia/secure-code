# HOW TO

## COMO PROTEGERSE CONTRA ATAQUES CSRF

El ataque Cross-Site Request Forgery (CSRF) es un tipo de vulnerabilidad de seguridad web que permite a un atacante engañar a un usuario autenticado para que realice acciones no deseadas en una aplicación web en la que está autenticado. A continuación se detallan las características clave del ataque CSRF:

### Características del Ataque CSRF
1. Engaño del Usuario: El atacante induce al usuario a realizar una acción sin su consentimiento. Esto se logra a menudo a través de un enlace malicioso o una imagen incrustada en un sitio web controlado por el atacante.

2. Uso de Sesiones Activas: El ataque aprovecha las sesiones de usuario autenticadas. Si el usuario ha iniciado sesión en una aplicación, sus cookies de sesión se enviarán automáticamente con la solicitud, lo que permite al atacante ejecutar acciones como si fuera el usuario legítimo.

3. Acciones No Deseadas: Las acciones que pueden ser ejecutadas incluyen cambiar configuraciones de cuenta, realizar transferencias de dinero, enviar formularios, entre otras, dependiendo de la aplicación web.

### Ejemplo de un Ataque CSRF
1. Situación Inicial: Un usuario está autenticado en su cuenta bancaria en un navegador y tiene una sesión activa.

2. El Ataque: Mientras el usuario está autenticado, visita un sitio web malicioso (controlado por el atacante) que contiene un script o un enlace diseñado para enviar una solicitud a la aplicación bancaria.

3. La Solicitud No Autorizada: El navegador del usuario envía la solicitud a la aplicación bancaria con las cookies de sesión del usuario, lo que permite que la acción se realice sin que el usuario se dé cuenta.

### Consecuencias de un Ataque CSRF
- Alteraciones No Deseadas: El usuario puede sufrir cambios en su cuenta sin su conocimiento.
- Pérdida de Datos: Puede resultar en la eliminación de datos importantes o la transferencia no autorizada de fondos.
- Compromiso de Seguridad: Puede poner en riesgo la seguridad de la cuenta del usuario y sus datos personales.

### COMO SE TRATA EN C#

Emisión y validación de un token temporal para peticiones POST:

#### FORMULARIO

```html
<form asp-action="ActionName" method="post">
    @Html.AntiForgeryToken()
    <!-- Otros campos del formulario -->
    <button type="submit">Enviar</button>
</form>
```
Se crea un campo hidden con el contenido del token

#### MÉTODO DE ACCIÓN

```C#
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult ActionName(Model model)
{
    if (ModelState.IsValid)
    {
        // Procesar el formulario
        return RedirectToAction("Index");
    }

    return View(model);
}
```
Al decorar con *[ValidateAntiForgeryToken]* se valida el token antiforgery de manera automática antes de ejecutar el método de acción.

## COMO SE VERIFICA UN CLIENTE CON UN CERTIFICADO DE USUARIO

```C#
public class CertificateMiddleware
{
    private readonly RequestDelegate _next;

    public CertificateMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Verificar si la cabecera X-SSL-CERT está presente
        if (context.Request.Headers.TryGetValue("X-SSL-CERT", out var certificateHeader))
        {
            // Convertir el valor de la cabecera en un certificado X509
            var certificate = ConvertToX509Certificate(certificateHeader);

            if (certificate != null && ValidateCertificate(certificate))
            {
                // El certificado es válido
                // Aquí se puede realizar la lógica adicional, como autenticación del usuario
            }
            else
            {
                // Manejar el caso de un certificado no válido
                context.Response.StatusCode = StatusCodes.Status403Forbidden; // Acceso denegado
                return;
            }
        }

        await _next(context);
    }

    private X509Certificate2 ConvertToX509Certificate(string certificateHeader)
    {
        // Eliminar los posibles prefijos de la cadena y convertirla a un byte array
        var certData = Convert.FromBase64String(certificateHeader);
        return new X509Certificate2(certData);
    }

    private bool ValidateCertificate(X509Certificate2 certificate)
    {
        // Validar el certificado (firma, fecha de validez, etc.)
        var chain = new X509Chain();
        var isValid = chain.Build(certificate);

        // Realizar más validaciones si es necesario
        return isValid;
    }
}

```

```C#

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Otras configuraciones...

    app.UseMiddleware<CertificateMiddleware>();

    app.UseRouting();
    
    // Otras configuraciones...
}

```
### COMO PROTEGER LOS DATOS CON MASKED DATA

Cada base de datos tiene su propio sitema de *MASKED DATA* para las pruebas se usará POSTGRESQL cuya versión es 14 o superior:

1. Instalar anon en el contenedor

```sh
apt update
apt install curl lsb-release
echo deb http://apt.dalibo.org/labs $(lsb_release -cs)-dalibo main > /etc/apt/sources.list.d/dalibo-labs.list
curl -fsSL -o /etc/apt/trusted.gpg.d/dalibo-labs.gpg https://apt.dalibo.org/labs/debian-dalibo.gpg
apt update
sudo apt install postgresql_anonymizer_17
```

2. Crear la Tabla con la Columna Enmascarada
    Primero, se debe crear la tabla con la columna de email enmascarada.

```sql
\c postgres;
CREATE DATABASE test2;
ALTER DATABASE test2 SET session_preload_libraries = 'anon';
\c test2;
CREATE EXTENSION anon CASCADE;
SELECT anon.init();
CREATE TABLE empleados (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    email VARCHAR(100)
);

INSERT INTO empleados (nombre, email) VALUES
    ('Juan Pérez', 'juan.perez@example.com'),
    ('María López', 'maria.lopez@example.com');
```
3. Configurar roles y permisos

```sql
CREATE ROLE hr LOGIN;
ALTER USER rh with PASSWORD('123abc.');
GRANT SELECT ON empleados TO hr;
```
4. Aplicar Data Masking
```sql
CREATE EXTENSION IF NOT EXISTS anon CASCADE;
SELECT anon.start_dynamic_masking();

SECURITY LABEL FOR anon ON ROLE hr IS 'MASKED';
SECURITY LABEL FOR anon ON COLUMN empleados.email IS 'MASKED WITH FUNCTION anon.partial_email(email)';
```
   

6. Pruebas
    Para verificar que la configuración funcione como se espera, puedes realizar las siguientes pruebas:
    Acceso con un Usuario Administrador:

```sh
psql -U postgres -d test2
```
```sql
SELECT * FROM empleados;
```
Este usuario debería ver el email completo.

Acceso con un Usuario No Administrador:
```sh
psql -U hr -d test2
```

```sql
SELECT * FROM empleados;
```

Este usuario debería ver el email enmascarado (por ejemplo, ****@example.com).

Si desea saber más a cerca de anonimyzers en postgreSQL visite https://postgresql-anonymizer.readthedocs.io/en/latest/

7. Consideraciones Adicionales

    - Seguridad: Asegurar que las políticas de RLS estén correctamente definidas y revisadas para evitar filtraciones de datos sensibles.
    - Control de Acceso: Es posible que desees establecer roles y permisos adicionales para controlar qué usuarios pueden realizar ciertas operaciones, como la inserción o actualización de datos.
    - Auditoría: Implemente un sistema de auditoría para registrar quién accede a qué datos y cuándo.

