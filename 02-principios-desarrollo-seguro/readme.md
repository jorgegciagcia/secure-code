# PRINCIPIOS DE DESARROLLO SEGURO

## Principios de Diseño Seguro

1. *Principio de menor privilegio:*

    - Descripción: Los usuarios, procesos y sistemas deben tener solo los permisos mínimos necesarios para realizar sus tareas. Si un componente se ve comprometido, el daño potencial se limita a lo que se le permitió.
    - Ejemplo: Un usuario que solo necesita acceder a datos no debería tener permisos para modificarlos o eliminarlos.

2. *Defensa en profundidad:*

    - Descripción: Utilizar múltiples capas de protección en diferentes niveles del sistema (aplicación, red, base de datos, etc.). Si una capa falla, las otras capas de seguridad pueden ayudar a mitigar el ataque.
    - Ejemplo: Combinar autenticación, cifrado y firewalls en una aplicación para protegerla desde diferentes ángulos.

3. *Validación estricta de entradas:*

    - Descripción: Todas las entradas del usuario deben ser validadas, filtradas o saneadas antes de ser procesadas. Esto previene ataques como la inyección de código, SQL injection o Cross-Site Scripting (XSS).
    - Ejemplo: Verificar que los campos de entrada solo contienen los tipos de datos esperados (por ejemplo, un número en lugar de una cadena de texto).

4. *Principio de mínima exposición (o "reducción de la superficie de ataque"):*

    - Descripción: Minimizar la cantidad de código, puntos de entrada y funciones accesibles desde el exterior. Exponer solo las funcionalidades necesarias.
    - Ejemplo: Limitar el acceso a una API para que solo usuarios autenticados puedan acceder a ciertos endpoints.

5. *Seguridad por defecto:*

    - Descripción: El software debe configurarse por defecto en un estado seguro, en lugar de asumir que los usuarios configurarán las opciones adecuadamente.
    - Ejemplo: Una aplicación debe requerir contraseñas fuertes de forma predeterminada, en lugar de permitir a los usuarios definir configuraciones inseguras.

6. *Seguridad en el diseño desde el inicio (Security by Design):*

    - Descripción: La seguridad debe considerarse desde las primeras fases del desarrollo del software y no ser un añadido al final. Esto garantiza que las decisiones de diseño tengan en cuenta las amenazas desde el principio.
    - Ejemplo: Incorporar análisis de amenazas en la fase de diseño de la arquitectura del sistema.

7. *Fallos seguros (Fail Secure):*

    - Descripción: Si un sistema falla, debe hacerlo de manera que no comprometa la seguridad. Los fallos deben ser manejados de forma segura, evitando que revelen información sensible o permitan el acceso no autorizado.
    - Ejemplo: Si una conexión de base de datos falla, la aplicación debe negar el acceso en lugar de concederlo de forma predeterminada.

8. *No confiar en la seguridad por la oscuridad:*

    - Descripción: La seguridad no debe depender únicamente del secreto del diseño o la implementación. Las defensas deben ser efectivas incluso si los atacantes conocen los detalles del sistema.
    - Ejemplo: Confiar en la solidez de un algoritmo de cifrado en lugar de ocultar su existencia o los detalles de implementación.

9. *Segregación de deberes:*

    - Descripción: Las responsabilidades críticas deben dividirse entre diferentes personas o sistemas para reducir el riesgo de fraude o abuso. Ninguna entidad debe tener el control total sobre todos los aspectos de una operación crítica.
    - Ejemplo: En un sistema financiero, un empleado que aprueba transacciones no debería ser el mismo que las ejecuta.

10. *Principio de economía de mecanismos:*

    - Descripción: Los sistemas deben ser lo más simples posible. Un diseño más sencillo reduce el número de posibles puntos de fallo y hace que sea más fácil auditar la seguridad.
    - Ejemplo: Utilizar mecanismos de autenticación y control de acceso estándar en lugar de diseñar soluciones personalizadas complejas.

11. *Auditoría y trazabilidad:*

    - Descripción: Es fundamental que los sistemas mantengan registros detallados de las acciones realizadas para detectar y responder a incidentes de seguridad. Las actividades críticas deben ser monitoreadas y auditable.
    - Ejemplo: Implementar logs de acceso a la base de datos para verificar quién ha accedido a los datos y cuándo.

12. *Principio de compartimentación:*

    - Descripción: Los sistemas deben dividirse en partes más pequeñas y aisladas, de modo que si una parte se compromete, no se comprometa todo el sistema.
    - Ejemplo: En una aplicación web, separar los módulos de front-end, back-end y base de datos para que no todos estén expuestos en el mismo nivel de seguridad.

### Principio de mínima exposición

El principio de mínima exposición es una estrategia clave en el diseño seguro de software que tiene como objetivo minimizar las posibles áreas donde un atacante puede intentar explotar vulnerabilidades en un sistema. Este principio se basa en la idea de que, al reducir el número de puntos de entrada y exposición del software, se disminuyen las oportunidades para que un atacante comprometa la seguridad del sistema.

**Conceptos Clave**

1. *Superficie de ataque:* La superficie de ataque se refiere a todas las formas posibles en que un atacante puede interactuar con un sistema, incluyendo interfaces, servicios, puertos abiertos, APIs, entradas de usuario, funciones expuestas, etc. Cuantas más interfaces o puntos de acceso expuestos tenga un sistema, mayor será su superficie de ataque.

2. *Reducción de la exposición:* Reducir la superficie de ataque implica eliminar, deshabilitar o restringir cualquier funcionalidad, servicio o recurso innecesario que no sea estrictamente requerido para el funcionamiento del sistema. Esto incluye cerrar puertos no utilizados, limitar las funcionalidades expuestas públicamente y reducir el acceso a ciertos componentes.

**Aplicación del Principio**

1. *Deshabilitar funcionalidades innecesarias:* Si una aplicación no necesita cierto protocolo o servicio, este debe estar deshabilitado o eliminado. Por ejemplo, si un servidor web no necesita soporte para FTP, este servicio debe estar apagado.

2. *Reducir las API públicas:* Solo las funciones que son necesarias para el uso público deben estar expuestas en una API. Las funciones internas que no necesitan ser accesibles desde fuera deben mantenerse privadas o protegidas.

3. *Cierre de puertos:* Si una aplicación o servidor tiene puertos abiertos que no se utilizan activamente, estos deben cerrarse para evitar que un atacante los explote. Por ejemplo, un servidor web solo debería tener el puerto 80 (HTTP) o 443 (HTTPS) abiertos, y cerrar otros puertos innecesarios.

4. *Menor cantidad de usuarios con privilegios elevados:* Reducir la cantidad de usuarios que tienen acceso a funciones o datos críticos. Los privilegios elevados deben ser limitados a un número reducido de personas, y solo cuando sea absolutamente necesario.

5. *Manejo cuidadoso de las entradas del usuario:* Validar y filtrar adecuadamente todas las entradas de usuario para evitar ataques como la inyección de SQL o la ejecución de comandos arbitrarios. Las entradas maliciosas pueden explotar una mayor superficie de ataque si no se controlan de manera adecuada.
6. *Segmentación de red y aislamiento de componentes:* Aislar diferentes partes del sistema en zonas de seguridad separadas. Por ejemplo, un servidor de base de datos no debe estar directamente accesible desde el exterior, sino que debería estar detrás de un servidor de aplicaciones, que actúe como intermediario.

**Beneficios**

- Menor probabilidad de ataques exitosos: Al reducir el número de puntos vulnerables, los atacantes tienen menos opciones para intentar explotar el sistema.

- Mejor gestión de la seguridad: Es más fácil asegurar y mantener un sistema con menos elementos expuestos.

- Mitigación de riesgos: En caso de que se encuentre una vulnerabilidad, el daño puede estar más contenido, ya que el atacante tendría menos acceso a otras partes del sistema.

### Principio de defensa en profundidad

El principio de defensa en profundidad es una estrategia de seguridad que implica la implementación de múltiples capas de defensa para proteger un sistema. Este enfoque se basa en la idea de que, si una capa de defensa falla, las capas adicionales seguirán proporcionando protección, lo que aumenta las posibilidades de detener un ataque antes de que alcance su objetivo final.

**Conceptos Clave**

1. *Múltiples capas de defensa:* La defensa en profundidad se fundamenta en la idea de que no se debe confiar en una única medida de seguridad. En su lugar, se deben utilizar varias técnicas y tecnologías de seguridad en diferentes niveles para ofrecer una protección más robusta.

2. *Detección y respuesta:* La implementación de mecanismos de detección, como sistemas de detección de intrusiones (IDS) y monitoreo continuo, permite identificar y responder rápidamente a los intentos de ataque, incluso si logran atravesar las primeras capas de defensa.

3. *Diversificación de las defensas:* Utilizar una variedad de tecnologías y estrategias de seguridad (firewalls, antivirus, autenticación multifactor, etc.) ayuda a proteger contra diferentes tipos de amenazas y vectores de ataque.

**Aplicación del Principio**

1. *Control de acceso físico:* La seguridad física puede incluir cerraduras en puertas, cámaras de vigilancia y seguridad en el lugar. Estas medidas impiden el acceso no autorizado a las instalaciones.

2. *Firewalls y filtrado de tráfico:* Un firewall actúa como la primera línea de defensa, filtrando el tráfico no deseado antes de que llegue a los sistemas internos. Esto se complementa con firewalls de próxima generación que pueden realizar análisis más profundos del tráfico.

3. *Segmentación de la red:* Dividir la red en segmentos aislados (por ejemplo, zonas DMZ, red interna y red de administración) limita el movimiento lateral de un atacante en caso de que logre acceder a un segmento.

4. *Autenticación y autorización:* Implementar múltiples métodos de autenticación (como contraseñas, autenticación de dos factores y biometría) proporciona una capa adicional de seguridad. También es esencial gestionar correctamente los permisos y accesos de los usuarios.

5. *Actualizaciones y parches de seguridad:* Mantener el software y los sistemas operativos actualizados es crucial para protegerse contra vulnerabilidades conocidas. Esto debe hacerse de manera regular y proactiva.

6. *Copia de seguridad y recuperación ante desastres:* Tener copias de seguridad de datos y un plan de recuperación ante desastres garantiza que, en caso de un ataque exitoso (como ransomware), se pueda restaurar la información sin pagar el rescate.

7. *Educación y concienciación del trabajador:* La capacitación regular sobre prácticas de seguridad, como la identificación de correos electrónicos de phishing y el uso seguro de contraseñas, es fundamental para reducir el riesgo de ataques basados en ingeniería social.

**Beneficios**

- Mayor resiliencia: La defensa en profundidad permite que un sistema sea más resistente a ataques, ya que los atacantes deben superar múltiples obstáculos.

- Reducción del riesgo de brechas: Al contar con varias capas de defensa, se minimizan las posibilidades de que un atacante tenga éxito en la explotación de una vulnerabilidad.

- Detección temprana de amenazas: La combinación de diferentes tecnologías de seguridad ayuda a detectar y responder a amenazas antes de que causen un daño significativo.

## Modelado de Amenazas

El modelado de amenazas es una técnica crítica en el desarrollo seguro de software que permite identificar, analizar y mitigar las posibles amenazas a la seguridad de una aplicación o sistema. Este proceso implica comprender cómo los atacantes podrían comprometer la seguridad de un sistema y qué medidas se pueden implementar para protegerlo.

Los objetivos del Modelado de Amenazas se pueden resumir en:

1. *Identificación de amenazas:* Detectar posibles amenazas que puedan afectar la confidencialidad, integridad y disponibilidad de la aplicación. Esto incluye ataques conocidos, como inyecciones, ataques de denegación de servicio (DoS), y amenazas internas.

2. *Evaluación de riesgos:* Analizar la probabilidad de que cada amenaza se materialice y el impacto que tendría en el sistema. Esto ayuda a priorizar las amenazas y enfocar los esfuerzos de mitigación en las más críticas.

3. *Diseño de mitigaciones:* Proponer medidas para reducir o eliminar los riesgos identificados. Esto puede incluir controles técnicos, procesos operativos y políticas de seguridad.

4. *Mejorar la comunicación:* Facilitar la comunicación entre los equipos de desarrollo, seguridad y gestión sobre los riesgos de seguridad y las decisiones de diseño que se tomen en función de ellos.

### Identificación y análisis de amenazas

El modelado de amenazas generalmente sigue un proceso estructurado que incluye los siguientes pasos:

1. *Definición del alcance:* Delimitar el sistema o aplicación a modelar, definiendo sus límites, componentes y las interacciones con otros sistemas.

2. *Identificación de activos:* Listar los activos críticos, como datos sensibles, sistemas, y recursos que necesitan protección.

3. *Creación de un diagrama de arquitectura:* Desarrollar un diagrama que represente la arquitectura del sistema, incluyendo componentes, flujos de datos, y puntos de entrada. Esto proporciona una visión clara de cómo interactúan los diferentes elementos del sistema.

4. *Identificación de amenazas:* Utilizar marcos de referencia como STRIDE o PASTA para identificar posibles amenazas en cada componente del sistema.

5. *Análisis de riesgos:* Evaluar la probabilidad y el impacto de cada amenaza identificada, priorizando las que representan mayores riesgos para el sistema.

6. *Definición de mitigaciones:* Proponer controles y medidas para mitigar cada amenaza priorizada, considerando tanto las soluciones técnicas como los procedimientos operativos.

7. *Documentación y revisión:* Documentar el proceso y los hallazgos, y revisar regularmente el modelo de amenazas a medida que el sistema evoluciona o se introducen nuevas funcionalidades.

### Herramientas y técnicas de modelado

** Herramienta de modelado de amenazas**

1. *Microsoft Threat Modeling Tool:*
    - Descripción: Herramienta oficial de Microsoft que permite crear diagramas de arquitectura y realizar un análisis de amenazas.
    - Características: Ofrece plantillas, ayuda a identificar amenazas basadas en el modelo STRIDE y permite generar un informe de seguridad.

2. *OWASP Threat Dragon:*
    - Descripción: Herramienta de modelado de amenazas de código abierto que permite crear diagramas de arquitectura de aplicaciones y analizar posibles amenazas.
    - Características: Facilita la colaboración en equipo, permite la exportación de modelos y se integra con sistemas de control de versiones.

**Técnicas de Modelado de Amenazas**

1. *STRIDE:*
    - Descripción: Estrategia de modelado de amenazas que se centra en seis categorías de amenazas.
        - Spoofing (Suplantación): Identidad falsa.
        - Tampering (Manipulación): Alteración no autorizada de datos.
        - Repudiation (Repudio): Afirmar no haber realizado la acción.
        - Information Disclosure (Divulgación de Información): Exposición no autorizada de datos.
        - Denial of Service (Denegación de Servicio): Interrupción del servicio.
        - Elevation of Privilege (Elevación de Privilegios): Obtención de permisos no autorizados.
    - Uso: Ayuda a clasificar y evaluar amenazas en función de estas categorías.

2. *PASTA (Process for Attack Simulation and Threat Analysis):*
     - Descripción: Un enfoque más dinámico que simula ataques para identificar vulnerabilidades.
     - Fases:
        - Definición de objetivos de seguridad.
        - Descripción del entorno de aplicación.
        - Identificación de posibles ataques.
        - Análisis de los resultados y mitigación.
    - Uso: Permite simular escenarios de ataque reales para evaluar la seguridad del sistema.

3. *Attack Trees:*
    - Descripción: Herramienta visual que representa las diferentes formas de realizar un ataque.
    - Estructura: Un árbol con un objetivo de ataque en la raíz y las distintas formas de lograrlo en las ramas.
    - Uso: Ayuda a visualizar y analizar las distintas amenazas y las acciones necesarias para mitigarlas.

4. *Diagramas de Flujo de Datos (DFD):*
    - Descripción: Representaciones gráficas de cómo fluye la información a través de un sistema.
    - Uso: Identifica los puntos de entrada y salida de datos, lo que ayuda a descubrir vulnerabilidades potenciales.

5. *Vulnerabilidades Comunes (CWE/SANS Top 25):*

    - Descripción: Listas de las vulnerabilidades más comunes que pueden ser utilizadas durante el modelado de amenazas.
    - Uso: Proporciona una referencia para identificar y mitigar vulnerabilidades en el sistema.

## Revisión de Arquitecturas

### Evaluación de arquitecturas seguras

Una arquitectura segura es un diseño estructural que incorpora principios, mecanismos y medidas de seguridad en todas las capas de una aplicación, con el fin de protegerla contra vulnerabilidades y ataquies tanto internas como externas. La arquitectura debe abordar tanto la seguridad del software como la infraestructura que lo soporta, garantizando la confidencialidad, integridad y disponibilidad de los datos y servicios.

Características clave de una arquitectura segura:

1.  Defensa en profundidad: Implementar múltiples capas de seguridad a nivel de red, aplicaciones, datos y usuarios. Esto asegura que si una capa es comprometida, otras capas seguirán protegiendo el sistema.
    
2.  Principio de privilegios mínimos: Cada componente o usuario del sistema debe tener únicamente los permisos necesarios para realizar su tarea, minimizando el riesgo de acceso no autorizado.
    
3.  Autenticación y autorización robusta: Utilizar mecanismos seguros de autenticación y autorización, como autenticación multifactor (MFA) y control de acceso basado en roles (RBAC), para restringir el acceso a los recursos del sistema.
    
4.  Protección de datos: Implementar cifrado tanto en tránsito como en reposo, asegurando que los datos sensibles no puedan ser accedidos sin la debida autorización.
    
5.  Segmentación y aislamiento: Separar componentes críticos del sistema mediante técnicas de segmentación de redes y entornos aislados (por ejemplo, mediante contenedores o redes virtuales privadas), para limitar el alcance de posibles brechas de seguridad.
    
6.  Monitorización continua y auditoría: Implementar soluciones de monitorización en tiempo real que detecten, alerten y registren actividad sospechosa o no autorizada, lo que permite una respuesta rápida ante incidentes.
    
7.  Protección contra vulnerabilidades conocidas: Utilizar herramientas de escaneo de vulnerabilidades y mantener el software y las dependencias actualizadas para mitigar el riesgo de explotación de vulnerabilidades conocidas.
    

Una arquitectura segura es un proceso dinámico que requiere actualizaciones continuas y adaptación a nuevas amenazas y tecnologías.

**Riesgos potenciales**

- Utilización de componentes con vulnerabilidades conocidas.
- Utilización de componentes anticuados, obsoletos o no soportados.
- Utilización de componentes que no han sido identificados.
- Apertura de puertos no indispensables.
- Comunicaciones no seguras y expuestas a terceros

**Recomendaciones de seguridad**

- Identificación de todos los componentes de la arquitectura para determinar los riesgos potenciales de seguridad.
- Bastionar el entorno completo siguiendo las recomendaciones de cada una de las normativas a aplicar en todos los entornos, como pueden ser desarrollo, pre-producción, producción, etc.
- Mantener los sistemas actualizados.
- Mantener los frameworks, librerías y módulos actualizados.
- En caso de tener que utilizar componentes con vulnerabilidades debido a necesidades de negocio, se recomienda realizar un informe con los posibles riesgos y mitigaciones. Estas mitigaciones deberán aplicarse en todos los entornos.
- Mejorar la seguridad perimetral lógica mediante la instalación de Firewalls, dispositivos IDS o similares, o mediante segmentación de redes.
- Garantizar que los datos quedan protegidos por mecanismos de autorización entre entornos mediante la segregación física o lógica y mediante copias de respaldo que aseguren su disponibilidad.
- Usar la versión más reciente del lenguaje de programación.
- Usar un Entorno Virtual como zona de trabajo del proyecto si aplica según el lenguaje de programación.
- Importación correcta de paquetes según lenguaje de programación. Paquetes instalados e importados comprobando exhaustivamente la seguridad de los paquetes a instalar.
- Desactivar todas las opciones de depuración en Producción que evite fuga de información en los mensajes de error detallados.
- Si hay que hacer una copia de las bases de datos de producción a desarrollo asegurarse de anonimizar la información sensible adecuadamente.

### Casos de estudio y ejemplos prácticos


#### Caso de Estudio 1: Desarrollo de una Aplicación de Banca en Línea

##### Contexto
Una empresa está desarrollando una aplicación de banca en línea que permite a los usuarios realizar transacciones financieras, consultar saldos y administrar cuentas.

##### Proceso de Modelado de Amenazas
1. **Identificación de Activos Críticos**: Datos personales de usuarios, credenciales de acceso, y registros de transacciones.
2. **Uso de STRIDE**: 
   - **Spoofing**: Riesgo de que un atacante suplante la identidad de un usuario legítimo.
   - **Tampering**: Posibilidad de que un atacante altere los detalles de una transacción.
   - **Information Disclosure**: Exposición de información sensible, como números de cuenta y saldos.
3. **Análisis de Resultados**: Se identificaron múltiples vulnerabilidades y se propusieron controles, como autenticación multifactor y cifrado de datos en reposo.

##### Mitigaciones Implementadas
- Autenticación multifactor para acceso a la cuenta.
- Cifrado de datos sensibles durante la transmisión.
- Monitoreo de actividades sospechosas para detectar comportamientos anómalos.

#### Caso de Estudio 2: Desarrollo de una Plataforma de Comercio Electrónico

##### Contexto
Una empresa está desarrollando una plataforma de comercio electrónico que permite a los usuarios comprar y vender productos en línea.

##### Proceso de Modelado de Amenazas
1. **Identificación de Activos Críticos**: Datos de tarjetas de crédito, información personal de los usuarios, inventarios de productos y registros de transacciones.
2. **Uso de STRIDE**:
   - **Spoofing**: Riesgo de que un atacante se haga pasar por un vendedor legítimo para estafar a los compradores.
   - **Tampering**: Posibilidad de que un atacante altere el precio de los productos en el carrito de compras para obtener beneficios.
   - **Information Disclosure**: Exposición de datos sensibles, como números de tarjetas de crédito y direcciones de envío, debido a una mala gestión de seguridad.
3. **Análisis de Resultados**: Se identificaron varias vulnerabilidades, y se propusieron controles, como validación de entrada y uso de HTTPS para la transmisión de datos.

##### Mitigaciones Implementadas
- Implementación de un sistema de revisión de vendedores para verificar la identidad de los usuarios que desean vender en la plataforma.
- Uso de HTTPS para proteger la transmisión de datos sensibles.
- Auditorías regulares de seguridad para detectar y corregir vulnerabilidades en el sistema.

---

#### Caso de Estudio 3: Desarrollo de un Sistema de Gestión de Contenidos (CMS)

##### Contexto
Una empresa está desarrollando un CMS que permite a los usuarios crear, editar y gestionar contenido en un sitio web.

##### Proceso de Modelado de Amenazas
1. **Identificación de Activos Críticos**: Contenido del sitio web, datos de usuarios, credenciales de acceso y configuraciones del sistema.
2. **Uso de STRIDE**:
   - **Spoofing**: Riesgo de que un atacante cree una cuenta de administrador falsa y obtenga acceso no autorizado.
   - **Tampering**: Posibilidad de que un atacante modifique contenido en el CMS, como artículos o imágenes, para insertar información errónea o maliciosa.
   - **Information Disclosure**: Exposición de información personal de los usuarios y configuraciones del CMS debido a un acceso indebido.
3. **Análisis de Resultados**: Se identificaron vulnerabilidades relacionadas con la gestión de usuarios y permisos, proponiendo controles como autenticación y autorización adecuadas.

##### Mitigaciones Implementadas
- Implementación de un sistema de autenticación robusto, incluyendo autenticación multifactor.
- Control de acceso basado en roles para limitar las acciones de los usuarios en el CMS.
- Monitoreo y registro de cambios en el contenido para detectar actividades no autorizadas. 



