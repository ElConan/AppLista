# 📱 AppLista - Aplicación de Notas

Aplicación móvil desarrollada en **.NET MAUI** que permite crear, editar, eliminar y buscar notas con persistencia local utilizando **SQLite**.

La aplicación implementa el patrón **MVVM**, navegación entre pantallas y almacenamiento local de datos.

---

# 🎯 Funcionalidades

- Crear nuevas notas
- Editar notas existentes
- Eliminar notas
- Buscar notas en tiempo real
- Exportar notas a formato JSON
- Persistencia local con SQLite
- Navegación entre lista y detalle de notas
- Interfaz moderna con tarjetas

---

# 🛠 Tecnologías utilizadas

- **.NET MAUI**
- **C#**
- **SQLite**
- **MVVM**
- **XAML**
- **Git / GitHub**

---

# 🏗 Arquitectura del proyecto

El proyecto sigue el patrón **MVVM (Model - View - ViewModel)**:


AppLista
│
├── Models
│ └── Nota.cs
│
├── ViewModels
│ ├── BaseViewModel.cs
│ ├── NotesViewModel.cs
│ └── NoteDetailViewModel.cs
│
├── Views
│ ├── MainPage.xaml
│ └── NoteDetailPage.xaml
│
├── Services
│ └── DBnota.cs
│
└── AppShell.xaml


### Descripción

**Model**
- Representa la estructura de los datos (Nota).

**View**
- Interfaz de usuario creada con XAML.

**ViewModel**
- Maneja la lógica y conecta la vista con los datos.

---

# 🗄 Base de datos

Se utiliza **SQLite** para almacenar las notas de forma local.

Campos de la entidad:

|   Campo   |   Tipo   |
|-----------|----------|
|    id     |   int    | 
|  titulo   |  string  |
| contenido |  string  |
| fecha_act | datetime |

Los datos permanecen almacenados incluso después de cerrar la aplicación.

---

# 📸 Capturas de pantalla

/screenshots
main.png
detail.png


Ejemplo:

![Lista de notas](screenshots/main.png)

![Detalle de nota](screenshots/detail.png)

---

# ⚙ Cómo ejecutar el proyecto

1. Clonar el repositorio


git clone https://github.com/tuusuario/AppLista.git


2. Abrir el proyecto en **Visual Studio 2022**

3. Restaurar paquetes NuGet

4. Ejecutar en:

- Android Emulator
- Dispositivo físico Android

---

# ✨ Extras implementados

- 🔍 Búsqueda de notas
- 📤 Exportación de notas a JSON
- 🎨 Interfaz mejorada con tarjetas

---

# 📹 Video demostración

El video muestra:

- creación de nota
- edición
- eliminación
- búsqueda
- persistencia de datos

Duración máxima: **4 minutos**

---

# 🚀 Mejoras futuras

- Notas favoritas (Pinned)
- Sincronización con la nube
- Notificaciones
- Exportación a PDF

---

# 👨‍💻 Autor

Proyecto desarrollado por:

**Nico Joel**

Estudiante de Tecnología en Desarrollo de Software
