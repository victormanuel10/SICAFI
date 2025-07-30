# Plan de Migración Incremental - SICAFI

## Objetivo
Migrar la aplicación SICAFI de .NET Framework 4.8/2.0 a .NET 8 de forma gradual, manteniendo la funcionalidad operativa en todo momento.

## Fase 1: Preparación y Análisis (Semana 1-2)

### 1.1 Inventario de Módulos
- [ ] **SICAFI_1.4.NET** (Aplicación principal - VB.NET + .NET Framework 4.8)
- [ ] **DATOS** (Capa de datos - VB.NET + .NET Framework 2.0)
- [ ] **REGLAS DEL NEGOCIO** (Lógica de negocio - VB.NET)
- [ ] **IMPRESION** (Generación de reportes - C# + .NET Framework 4.8)

### 1.2 Análisis de Dependencias
- [ ] iTextSharp 5.5.9.0 (PDF)
- [ ] Microsoft Office Interop Word 12.0.0.0
- [ ] IrisSkin2 (Temas)
- [ ] SQL Server (Base de datos)
- [ ] SQLite (Módulo IMPRESION)

### 1.3 Crear Proyecto Base .NET 8
- [ ] Crear solución nueva con .NET 8
- [ ] Configurar estructura de carpetas
- [ ] Configurar conexiones de base de datos

## Fase 2: Migración del Módulo DATOS (Semana 3-4)

### 2.1 Crear Proyecto DATOS .NET 8
```bash
# Crear nuevo proyecto
dotnet new classlib -n SICAFI.Datos -f net8.0
```

### 2.2 Migrar Clases de Conexión
- [ ] Migrar `cConexion.vb` → `Conexion.cs`
- [ ] Migrar `cExecuteNonQuery.vb` → `ExecuteNonQuery.cs`
- [ ] Migrar `cExecuteQuery.vb` → `ExecuteQuery.cs`
- [ ] Actualizar a Microsoft.Data.SqlClient

### 2.3 Migrar Funciones de Conexión
- [ ] Migrar `cla_ConnectionInstance.vb` → `ConnectionInstance.cs`
- [ ] Migrar `cla_ConnectionString.vb` → `ConnectionString.cs`
- [ ] Migrar `cla_ConnectionStringProyectos.vb` → `ConnectionStringProyectos.cs`

## Fase 3: Migración de REGLAS DEL NEGOCIO (Semana 5-8)

### 3.1 Crear Proyecto REGLAS DEL NEGOCIO .NET 8
```bash
dotnet new classlib -n SICAFI.ReglasNegocio -f net8.0
```

### 3.2 Migrar Módulos por Prioridad
1. **Alta Prioridad:**
   - [ ] Ficha Predial
   - [ ] Certificación de Estrato
   - [ ] Liquidación de Predial
   - [ ] Tercero

2. **Media Prioridad:**
   - [ ] Mutaciones
   - [ ] Resoluciones
   - [ ] Consultas
   - [ ] Validaciones

3. **Baja Prioridad:**
   - [ ] Utilidades
   - [ ] Variables públicas
   - [ ] Funciones Microsoft

## Fase 4: Migración de IMPRESION (Semana 9-10)

### 4.1 Actualizar Proyecto IMPRESION
- [ ] Migrar de .NET Framework 4.8 a .NET 8
- [ ] Actualizar iTextSharp a versión compatible
- [ ] Migrar clases de modelo
- [ ] Migrar clases de negocio

### 4.2 Actualizar Dependencias
- [ ] iTextSharp → iText7
- [ ] SQLite → Microsoft.Data.Sqlite
- [ ] Actualizar referencias de System.Data

## Fase 5: Migración de la Aplicación Principal (Semana 11-16)

### 5.1 Crear Aplicación Principal .NET 8
```bash
dotnet new winforms -n SICAFI.App -f net8.0
```

### 5.2 Migrar Formularios por Módulo
1. **Autenticación y Navegación:**
   - [ ] Login
   - [ ] Bienvenida
   - [ ] Contenedor principal

2. **Módulos Core:**
   - [ ] Ficha Predial
   - [ ] Certificación de Estrato
   - [ ] Tercero

3. **Módulos Secundarios:**
   - [ ] Bitácora
   - [ ] Consultas
   - [ ] Reportes

### 5.3 Migrar Recursos
- [ ] Iconos y imágenes
- [ ] Archivos de configuración
- [ ] Temas y estilos

## Fase 6: Integración y Pruebas (Semana 17-18)

### 6.1 Integración de Módulos
- [ ] Conectar todos los proyectos
- [ ] Configurar dependencias
- [ ] Resolver referencias circulares

### 6.2 Pruebas Funcionales
- [ ] Pruebas unitarias
- [ ] Pruebas de integración
- [ ] Pruebas de usuario

### 6.3 Optimización
- [ ] Optimizar rendimiento
- [ ] Mejorar experiencia de usuario
- [ ] Documentar cambios

## Estructura del Proyecto Migrado

```
SICAFI.NET8/
├── SICAFI.App/                 # Aplicación principal (WinForms)
├── SICAFI.Datos/              # Capa de datos
├── SICAFI.ReglasNegocio/      # Lógica de negocio
├── SICAFI.Impresion/          # Generación de reportes
├── SICAFI.Comun/              # Clases compartidas
├── SICAFI.Tests/              # Pruebas unitarias
└── SICAFI.Instalador/         # Instalador moderno
```

## Herramientas y Tecnologías Modernas

### Base de Datos
- **Microsoft.Data.SqlClient** (en lugar de System.Data.SqlClient)
- **Entity Framework Core** (opcional, para ORM)

### Reportes
- **iText7** (en lugar de iTextSharp 5.x)
- **PdfSharp** (alternativa)

### Interfaz
- **Windows Forms** (mantener para compatibilidad)
- **WPF** (opcional, para módulos nuevos)

### Desarrollo
- **Visual Studio 2022** o **VS Code**
- **Git** para control de versiones
- **NuGet** para gestión de paquetes

## Cronograma Estimado

| Fase | Duración | Entregables |
|------|----------|-------------|
| 1. Preparación | 2 semanas | Análisis completo, plan detallado |
| 2. DATOS | 2 semanas | Módulo de datos migrado |
| 3. REGLAS DEL NEGOCIO | 4 semanas | Lógica de negocio migrada |
| 4. IMPRESION | 2 semanas | Generación de reportes migrada |
| 5. APLICACIÓN PRINCIPAL | 6 semanas | Interfaz de usuario migrada |
| 6. INTEGRACIÓN | 2 semanas | Aplicación completa funcional |

**Total estimado: 18 semanas (4.5 meses)**

## Próximos Pasos Inmediatos

1. **Crear el proyecto base .NET 8**
2. **Migrar el módulo DATOS** (más simple, menor riesgo)
3. **Configurar conexiones de base de datos**
4. **Crear pruebas básicas**

¿Te parece bien empezar con la Fase 1? Podemos comenzar creando el proyecto base y migrando el módulo DATOS paso a paso. 
¡Perfecto! Entonces, los próximos pasos serán:

- Crear la solución base en .NET 8 y el proyecto de la capa de datos (`SICAFI.Datos`).
- Migrar las clases de conexión y probar la conectividad a la base de datos.
- Documentar cualquier incompatibilidad o ajuste necesario durante la migración.

A medida que avancemos, iremos validando cada módulo migrado para asegurar que la funcionalidad se mantenga. Si surge alguna duda o bloqueo técnico, lo documentamos y lo resolvemos en conjunto.

**Siguiente acción:**  
Ejecutar en la terminal:
dotnet new sln -n SICAFI
dotnet new classlib -n SICAFI.Datos -f net8.0
dotnet sln add SICAFI.Datos/SICAFI.Datos.csproj
> **Ejecutar en la terminal:**
>
> ```bash
> dotnet new sln -n SICAFI
> dotnet new classlib -n SICAFI.Datos -f net8.0
> dotnet sln add SICAFI.Datos/SICAFI.Datos.csproj
> ```

Una vez ejecutados estos comandos, tendrás la solución base y el primer proyecto de la capa de datos listos para comenzar la migración.
 dotnet new classlib -n SICAFI.Datos -f net8.0
  dotnet new sln -n SICAFI
  dotnet sln add SICAFI.Datos/SICAFI.Datos.csproj
### Consideraciones adicionales para la migración

- **Respaldo:** Antes de migrar cualquier módulo, realizar un respaldo completo del código fuente y la base de datos.
- **Control de versiones:** Usar ramas separadas en Git para cada fase/módulo migrado.
- **Pruebas:** Implementar pruebas unitarias básicas en cada módulo migrado para validar la funcionalidad.
- **Documentación:** Registrar cualquier cambio relevante, incompatibilidad o ajuste realizado durante la migración.
- **Comunicación:** Mantener reuniones periódicas para revisar avances y resolver bloqueos técnicos.

### Recomendaciones técnicas

- Priorizar la migración de componentes sin dependencias externas complejas.
- Reemplazar librerías obsoletas por alternativas compatibles con .NET 8 cuando sea necesario.
- Aprovechar las nuevas características de C# y .NET 8 para mejorar el código donde sea posible, sin alterar la lógica de negocio.

### Próximos hitos

- [ ] Validar la conectividad a la base de datos desde el nuevo proyecto `SICAFI.Datos`.
- [ ] Migrar y probar las clases de acceso a datos.
- [ ] Definir el plan de migración para la capa de reglas de negocio.

> **¡Listo para comenzar la migración incremental de SICAFI a .NET 8!**

---

## Anexo: Checklist de Migración de Ficha Predial

A continuación se detalla un checklist específico para la migración del módulo **Ficha Predial** (formularios y lógica asociada):

### 1. Formularios principales a migrar

- [ ] `frm_FICHPRED.vb` (Formulario principal de ficha predial)
- [ ] `frm_insertar_FICHPRED.vb` (Formulario de inserción)
- [ ] `frm_consultar_FICHPRED.vb` (Formulario de consulta)
- [ ] Archivos `.resx` asociados a cada formulario

### 2. Pasos sugeridos para cada formulario

1. **Inventariar controles y dependencias**  
   - Listar todos los controles (TextBox, ComboBox, DataGridView, etc.)
   - Identificar dependencias con otras clases/proyectos (por ejemplo, `REGLAS_DEL_NEGOCIO`).

2. **Migrar la interfaz**  
   - Crear el formulario en WinForms .NET 8 (o MAUI si se decide multiplataforma).
   - Replicar la estructura y controles.

3. **Migrar la lógica de eventos y métodos**  
   - Copiar y adaptar los métodos de eventos (Click, Load, etc.).
   - Revisar el acceso a base de datos y actualizar a `Microsoft.Data.SqlClient`.

4. **Migrar recursos y cadenas**  
   - Migrar archivos `.resx` y verificar compatibilidad de recursos (imágenes, cadenas, etc.).

5. **Pruebas funcionales**  
   - Validar que cada formulario funcione igual que en la versión original.
   - Documentar cualquier diferencia o ajuste necesario.

### 3. Consideraciones técnicas

- Revisar el uso de tipos de datos y conversiones (especialmente entre VB.NET y C#).
- Reemplazar cualquier API obsoleta o no soportada en .NET 8.
- Si se usan componentes de terceros (por ejemplo, controles de terceros en los formularios), buscar alternativas compatibles.

### 4. Ejemplo de migración de un formulario

Supongamos que migramos `frm_FICHPRED.vb`:

- Crear un nuevo formulario `FrmFichPred.cs` en el proyecto de presentación.
- Migrar la lógica de inicialización y eventos (`New`, `Load`, botones, etc.).
- Adaptar el acceso a datos para usar las nuevas clases migradas en `SICAFI.Datos`.
- Probar la carga, consulta e inserción de fichas prediales.

---

**Este checklist puede repetirse para cada formulario o módulo funcional.**  
Se recomienda documentar los hallazgos y dificultades en cada paso para facilitar la migración incremental y la transferencia de conocimiento.
### 5. Checklist de migración técnica para Ficha Predial

- [ ] Revisar y migrar los constructores personalizados (`New(ByVal id As Integer)`, `New(ByVal tbl As DataTable)`) a C#.
- [ ] Migrar variables locales y su inicialización (por ejemplo, `SqlCommand`, `SqlConnection`, `DataSet`, etc.) usando `Microsoft.Data.SqlClient` y convenciones de C#.
- [ ] Adaptar la instancia singleton del formulario (`instance()`) a patrón adecuado en C# (por ejemplo, propiedad estática).
- [ ] Migrar y adaptar los métodos de inicialización y carga de datos (`pro_InicializarComponentes`, `pro_LimpiarCampos`).
- [ ] Revisar y migrar el manejo de eventos de controles (botones, combos, etc.).
- [ ] Migrar el acceso a recursos `.resx` y verificar compatibilidad de imágenes, cadenas y otros recursos.
- [ ] Validar la lógica de negocio conectada a `REGLAS_DEL_NEGOCIO` y actualizar referencias a los nuevos proyectos migrados.
- [ ] Probar la funcionalidad de consulta, inserción y edición de fichas prediales en el nuevo entorno.
- [ ] Documentar cualquier diferencia funcional detectada tras la migración.

### 6. Recomendaciones adicionales

- Migrar primero la lógica de acceso a datos y negocio antes de los formularios para facilitar pruebas unitarias.
- Utilizar herramientas de análisis de dependencias para identificar referencias cruzadas entre formularios y módulos.
- Mantener un registro de cambios y problemas encontrados durante la migración para futuras fases.

---ya lo estas ejecutando o yo debo hacer algo ? 


