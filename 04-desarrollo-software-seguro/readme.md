# DESARROLLO DE SOFTWARE SEGURO

## Prácticas de codificación segura

### Java:

- Validación de entradas: Usa el paquete javax.validation para implementar reglas estrictas de validación de entrada.
- Evitar serialización insegura: Deshabilitar la deserialización de objetos no confiables y restringir el uso de la serialización/deserialización a entornos controlados.
- Manejo seguro de excepciones: Evita exponer detalles internos en las excepciones, registra los errores en el servidor y devuelve mensajes de error genéricos al usuario.
- Uso de frameworks seguros: Emplea frameworks como Spring Security para manejar autenticación y autorización de forma segura.
- Protección contra inyecciones SQL: Utiliza PreparedStatement para consultas parametrizadas y evita concatenar entradas de usuario en las consultas SQL.
- Uso de APIs criptográficas seguras: Java proporciona APIs robustas en javax.crypto y java.security. Evita implementar criptografía manualmente y usa bibliotecas probadas.

### C#:

- Validación de datos de usuario: Usa las validaciones de datos proporcionadas por el espacio de nombres System.ComponentModel.DataAnnotations para validar las entradas de usuario.
- Manejo seguro de cadenas: Escapa correctamente las cadenas que pueden ser interpretadas por SQL, HTML o JavaScript para evitar inyecciones y ataques de XSS.
- Protección contra inyecciones SQL: Utiliza SqlCommand con consultas parametrizadas en lugar de concatenar directamente las entradas de usuario.
- Cifrado: Usa el espacio de nombres System.Security.Cryptography para operaciones criptográficas. Usa algoritmos estándar como AES y RSA, y evita la creación de métodos personalizados de cifrado.
- Manejo de excepciones: Maneja las excepciones correctamente, evitando exponer detalles innecesarios al usuario. Registra errores de manera centralizada y devuelve mensajes genéricos en la interfaz.
- Prevención de CSRF y XSS: En aplicaciones web, utiliza el AntiForgeryToken y siempre codifica las salidas de datos en HTML usando HttpUtility.HtmlEncode.

### Python:

- Validación de entradas: Emplea bibliotecas como validators o WTForms para manejar la validación de entradas. Usa expresiones regulares con cuidado y valida por listas blancas siempre que sea posible.
- Evitar inyecciones SQL: Usa ORMs como SQLAlchemy o psycopg2 para trabajar con bases de datos, siempre empleando consultas parametrizadas.
- Gestión de excepciones: No expongas mensajes detallados de excepciones a los usuarios finales. Emplea un registro centralizado de errores para depurar problemas de forma segura.
- Cifrado y hashing: Usa bibliotecas seguras como cryptography o hashlib para manejar cifrado y hashes de contraseñas, evitando funciones antiguas como md5 y sha1.
- Prevención de inyecciones en comandos del sistema: Usa subprocess con parámetros en lugar de os.system() para evitar ejecutar comandos del sistema que incluyan datos no confiables.
- Protección contra XSS: En aplicaciones web, siempre codifica la salida de datos hacia el HTML usando frameworks seguros como Flask o Django, que incluyen medidas preventivas contra XSS.

## Buenas prácticas y anti-patrones

### Buenas Prácticas:

- Principio de responsabilidad única: Cada función o clase debe tener una única responsabilidad. Esto facilita el mantenimiento, la prueba y la evolución del código.
- Uso de controles de acceso: Implementa controles de acceso basados en roles y asegura que se revisen en cada acción que involucre recursos sensibles.
- Definir políticas claras de autenticación: Usa autenticación multifactor y métodos seguros para manejar credenciales, como OAuth, JWT o SAML.
 Cifrado robusto: Almacena y transmite datos sensibles utilizando algoritmos de cifrado actualizados y probados (por ejemplo, AES-256 para cifrado simétrico, RSA-2048 o superior para cifrado asimétrico).
- Pruebas de seguridad automatizadas: Incorpora herramientas automáticas de pruebas de seguridad (como SAST o DAST) en el ciclo de integración continua para detectar vulnerabilidades en las primeras fases del desarrollo.
- Documentación clara: Documenta el código con descripciones detalladas sobre el propósito y comportamiento de funciones críticas, especialmente en áreas que gestionen la seguridad.

### Anti-patrones:

- SQL concatenado con entradas de usuario: Concatenar cadenas de consulta SQL directamente con entradas de usuario es un vector clásico para la inyección de SQL. Este es un grave anti-patrón que se puede evitar con el uso de consultas parametrizadas.
- No manejar adecuadamente los errores: Exponer mensajes de error detallados al usuario o no manejar excepciones puede revelar información crítica a posibles atacantes.
- Uso de contraseñas incrustadas en el código: Es peligroso almacenar credenciales o claves en el código fuente. Un mejor enfoque es utilizar servicios de gestión de secretos.
- Uso de criptografía casera: Implementar algoritmos de cifrado sin usar librerías probadas puede introducir fallos serios en la seguridad. Siempre usa bibliotecas estándar bien auditadas.
- Deshabilitar la validación de entrada del lado del servidor: Algunas aplicaciones confían solo en la validación del lado del cliente, lo que puede ser fácilmente ignorado por un atacante. La validación del lado del servidor es imprescindible.
- Exponer APIs sin autenticación: Las APIs que no están protegidas adecuadamente pueden ser vulnerables a abusos. Siempre deben requerir autenticación y autorización, y usar HTTPS para la transmisión de datos.

## Uso de Librerías y Dependencias
### Gestión de dependencias seguras
- Control estricto de versiones: Al gestionar dependencias, es importante utilizar versiones específicas en lugar de versiones con rangos abiertos (>=1.0.0). Esto evita la instalación automática de actualizaciones que podrían introducir vulnerabilidades o cambios no deseados. El uso de herramientas como npm, pip, NuGet o Maven permite especificar versiones exactas o restringir las actualizaciones a versiones probadas.

- Revisiones periódicas: Las dependencias deben ser revisadas regularmente para detectar actualizaciones de seguridad críticas. Los gestores de paquetes suelen incluir comandos para verificar actualizaciones de dependencias, como npm audit o pip list --outdated. Integrar auditorías automáticas de dependencias en el ciclo de integración continua asegura que no se utilicen versiones vulnerables.

- Firmado de dependencias: Si es posible, es recomendable utilizar dependencias firmadas digitalmente para asegurar su integridad y autenticidad. Por ejemplo, NuGet permite la firma de paquetes, lo que reduce el riesgo de utilizar bibliotecas manipuladas por terceros malintencionados.

- Minimización de dependencias: Solo se deben incluir las dependencias absolutamente necesarias para el proyecto. Agregar dependencias innecesarias incrementa la superficie de ataque, ya que cada dependencia adicional puede contener vulnerabilidades que comprometan la seguridad del proyecto. Es importante evaluar si una dependencia externa es imprescindible o si el problema puede resolverse con código propio.

- Herramientas de gestión de vulnerabilidades: Herramientas como Snyk, OWASP Dependency-Check, Retire.js o WhiteSource permiten detectar dependencias vulnerables. Estas herramientas analizan las dependencias de un proyecto y emiten advertencias si alguna de ellas tiene vulnerabilidades conocidas. Integrar estas herramientas en el flujo de trabajo asegura una vigilancia continua sobre la seguridad de las dependencias.

### Evaluación de la seguridad de librerías de terceros
- Reputación y madurez de la librería: Antes de integrar una librería de terceros, es esencial evaluar su reputación y el soporte de la comunidad. Librerías que son ampliamente utilizadas y que cuentan con una comunidad activa suelen ser más seguras, ya que los problemas de seguridad se descubren y corrigen más rápidamente. También se debe revisar el historial de commits y lanzamientos de la librería para asegurarse de que sigue siendo mantenida.

- Auditoría de código fuente: Siempre que sea posible, revisa el código fuente de las librerías para evaluar su seguridad, especialmente si se trata de librerías críticas que manejan datos sensibles o realizan operaciones de seguridad (cifrado, autenticación, etc.). Para proyectos de código abierto, esto puede incluir la lectura de issues, pull requests o contribuciones de seguridad realizadas por la comunidad.

- Manejo de licencias: Asegúrate de que las librerías de terceros cumplan con las licencias requeridas por el proyecto y de que no presenten riesgos legales que puedan comprometer el software final. Algunas licencias, como GPL, pueden imponer restricciones que no son compatibles con ciertos tipos de proyectos.

- Revisión de vulnerabilidades conocidas: Antes de incorporar una nueva librería, consulta bases de datos públicas de vulnerabilidades como NVD (National Vulnerability Database) o la propia OWASP para verificar si tiene vulnerabilidades conocidas. Además, herramientas como GitHub Dependabot o npm audit también pueden advertir sobre vulnerabilidades en las dependencias.

- Política de actualizaciones de la librería: Es importante verificar cómo se gestionan las actualizaciones de seguridad de las librerías que se usan. Si una librería no publica actualizaciones de seguridad o tarda mucho en responder a los reportes de vulnerabilidades, puede ser un indicio de que la librería no es segura a largo plazo.

- Entorno de pruebas aislado: Antes de integrar una librería en el proyecto principal, evalúa su comportamiento en un entorno de pruebas aislado. Esto ayuda a detectar posibles fallos o vulnerabilidades que podrían afectar la seguridad del sistema. También es útil correr pruebas de seguridad, como fuzzing o análisis estático, sobre la librería para identificar posibles problemas.

- Revisión del historial de seguridad: Revisar si la librería ha tenido vulnerabilidades en el pasado y cómo fueron gestionadas es fundamental. Una respuesta rápida y transparente ante una vulnerabilidad refleja un equipo de desarrollo comprometido con la seguridad.

## Checkeo de librerías vulnerables:

### C#

```sh
dotnet list package --vulnerable
```

### JAVA

1. Usar OWASP Dependency-Check
OWASP Dependency-Check es una herramienta popular que analiza dependencias de proyectos Java en busca de vulnerabilidades conocidas a través de la base de datos NVD (National Vulnerability Database).

#### OWASP Dependency-Check:

1. Instalación

- Descarga e instala la versión apropiada de Dependency-Check desde OWASP Dependency-Check (https://owasp.org/www-project-dependency-check/)

- Integración con Maven o Gradle: Si tu proyecto utiliza Maven o Gradle, Dependency-Check se puede integrar directamente en el proceso de construcción.

- Maven: Agrega el plugin a tu archivo pom.xml:

```xml
<plugin>
  <groupId>org.owasp</groupId>
  <artifactId>dependency-check-maven</artifactId>
  <version>8.0.0</version> <!-- Verifica la última versión -->
  <executions>
    <execution>
      <goals>
        <goal>check</goal>
      </goals>
    </execution>
  </executions>
</plugin>
```
    Ejecutar el análisis:

```bash
mvn verify
```

- Gradle: Agrega el plugin a tu archivo build.gradle:

```groovy

plugins {
    id "org.owasp.dependencycheck" version "8.0.0"
}

dependencyCheck {
    failBuildOnCVSS = 7 // Falla si hay vulnerabilidades de alta gravedad
}
```
    Ejecutar el análisis:

```bash
./gradlew dependencyCheckAnalyze

```
3. Revisar el informe generado: Dependency-Check generará un informe con detalles sobre las vulnerabilidades encontradas en las dependencias de tu proyecto.

#### Snyk
Snyk es una plataforma muy utilzada para analizar vulnerabilidades en dependencias. Ofrece una CLI y se integra con Maven, Gradle, y otros sistemas de construcción.

Pasos para usar Snyk:

1. Instalación: Instala Snyk CLI usando npm:

``` bash
npm install -g snyk
```
2. Autenticación: Regístrate en Snyk y autenticar el CLI con una cuenta:

```bash
snyk auth
```
3. Escanear dependencias: Navege a la carpeta del proyecto y ejecuta el siguiente comando para realizar el análisis:

- Maven:

```bash
snyk test --file=pom.xml
```
- Gradle:

```bash
snyk test --file=build.gradle
```

  Snyk generará un informe con detalles sobre las vulnerabilidades encontradas y sugerencias para actualizar las dependencias.

#### Revisión manual con bases de datos de vulnerabilidades

National Vulnerability Database (NVD): Puedes buscar manualmente vulnerabilidades conocidas en dependencias utilizando el sitio de la NVD.

CVE Details: También puedes usar CVE Details para buscar vulnerabilidades específicas de las bibliotecas que estés utilizando en tu proyecto.

### PYTHON

```sh
pip install pip-audit
```
```sh
pip-audit
```

## Controles de Seguridad en Aplicaciones Web

### Protección contra ataques comunes (XSS, CSRF, SQL Injection)

Ver 99-labs/injections

### Implementación de HTTPS y seguridad de cookies

#### Configuración segura HTTPS

La configuración segura de HTTPS es crucial para proteger la transmisión de datos entre clientes y servidores. A continuación se detallan las mejores prácticas para asegurar correctamente una conexión HTTPS:

1. Uso de Certificados SSL/TLS Validados
    - Certificado válido y confiable: Utilizar un certificado SSL/TLS emitido por una autoridad de certificación (CA) confiable y reconocida. Los certificados autofirmados no son adecuados para producción ya que no garantizan la autenticidad del servidor.
    - Certificados de dominio y organización: Dependiendo del nivel de seguridad, puedes optar por un certificado de validación de dominio (DV), validación de organización (OV) o validación extendida (EV), siendo este último el más riguroso.
  - Renovación de certificados: Asegúrate de que los certificados se renueven antes de expirar para evitar interrupciones en la seguridad.
2. Configuración de Protocolos TLS
    - Usar versiones seguras de TLS: Asegúrate de utilizar la versión más reciente y segura del protocolo TLS (como TLS 1.3 o al menos TLS 1.2). Las versiones antiguas de SSL y TLS (como TLS 1.0 y 1.1) deben deshabilitarse debido a vulnerabilidades conocidas.
    - Deshabilitar SSL: SSL (Secure Sockets Layer) debe estar completamente deshabilitado, ya que se ha considerado inseguro durante muchos años.
3. Cipher Suites Seguras
    - Elegir cifrados modernos y seguros: Las suites de cifrado (cipher suites) determinan cómo se cifran los datos en tránsito. Asegúrate de habilitar solo las suites de cifrado fuertes, como AES-256-GCM y ChaCha20-Poly1305.
    - Eliminar cifrados débiles: Deshabilita cifrados obsoletos como RC4, DES, 3DES, y MD5, que son vulnerables a ataques criptográficos.
    - Preferir Forward Secrecy (PFS): Habilita cifrados que ofrezcan Perfect Forward Secrecy (PFS), como ECDHE o DHE, para proteger el tráfico anterior si alguna clave se ve comprometida en el futuro.
4. HSTS (HTTP Strict Transport Security)
    - Habilitar HSTS: Implementa el encabezado HTTP Strict Transport Security (HSTS) para obligar a los navegadores a interactuar solo a través de HTTPS. Esto previene ataques de tipo "downgrade" donde un atacante intenta forzar una conexión HTTP no segura.
```conf
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
```
    - Configurar max-age correctamente: El parámetro max-age define cuánto tiempo los navegadores recordarán que el sitio solo debe usar HTTPS. Debe establecerse en un valor elevado (por ejemplo, 1 año).
5. Certificados Wildcard y SAN
    - Certificados Wildcard: Son útiles para proteger múltiples subdominios bajo un único dominio, por ejemplo, *.example.com. Esto reduce la complejidad de la gestión de certificados.
    - Certificados SAN (Subject Alternative Name): Permiten asegurar varios dominios y subdominios diferentes en un solo certificado, lo cual es útil en aplicaciones complejas.
6. Cifrado Suficiente en la Longitud de las Claves
    - Longitud de claves: Utiliza claves de al menos 2048 bits para RSA o 256 bits para claves basadas en el estándar ECC (Elliptic Curve Cryptography), ya que estas proporcionan un nivel de seguridad adecuado.
7. Revisión de Configuración y Pruebas
    - Auditar la configuración regularmente: Revisa y ajusta la configuración de HTTPS periódicamente para adaptarla a nuevas recomendaciones de seguridad.
    - Usar herramientas de prueba: Herramientas como SSL Labs permiten realizar auditorías de la configuración SSL/TLS de un servidor, evaluando su seguridad y sugiriendo mejoras.
8. Configuración del Servidor
    - Deshabilitar renegociación insegura: Asegúrate de que la renegociación SSL esté configurada correctamente para evitar ataques de tipo renegotiation.
    - Configurar el servidor para solo HTTPS: Redireccionar todo el tráfico HTTP a HTTPS, asegurando que ninguna solicitud se procese sin cifrado.

  Ejemplo en nginx:
```conf
server {
    listen 80;
    server_name example.com;
    return 301 https://$host$request_uri;
}
```
9. Revisar Vulnerabilidades Frecuentes
    - Protección contra ataques de tipo BEAST, CRIME, POODLE y Heartbleed: Configurar el servidor y las suites de cifrado para mitigar vulnerabilidades comunes como BEAST (TLS 1.0), CRIME (TLS compression), POODLE (SSLv3) y asegurar que el servidor no sea vulnerable a ataques como Heartbleed.
10. Evitar Certificados Revocados
    - OCSP Stapling: Habilita OCSP Stapling para que el servidor presente el estado del certificado al cliente, mejorando la seguridad y el rendimiento.
