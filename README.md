# Proyecto: Juego de Gato y Sierras 🐱⚙️

Un juego en 2D desarrollado con Unity, donde controlas a un gato que debe esquivar sierras mientras acumula puntos.

## Descripción

En este juego, el jugador controla un gato que se mueve hacia la izquierda o derecha en función de la posición del dedo o del clic en la pantalla. El objetivo principal es esquivar las sierras que aparecen y suman puntos al caer. El juego termina si el gato es alcanzado por una sierra.

## Características
- **Control táctil:** Compatible con dispositivos móviles para una experiencia fluida.
- **Física realista:** Animaciones y movimiento natural gracias al uso de Rigidbody2D.
- **Sonido dinámico:** Las sierras emiten sonido al moverse y lo detienen al colisionar.
- **Sistema de puntuación:** Incrementa la puntuación al esquivar sierras.
- **Escena de Game Over:** Muestra el final del juego y da la opción de reiniciar o volver al menú principal.

---

## Instrucciones de Juego
1. **Controles:** 
   - Pulsa en la mitad izquierda de la pantalla para mover al gato hacia la izquierda.
   - Pulsa en la mitad derecha para mover al gato hacia la derecha.
2. **Objetivo:** 
   - Evita las sierras que caen desde la parte superior de la pantalla.
   - Gana puntos cada vez que una sierra toca el suelo.
3. **Fin del Juego:** 
   - El juego termina cuando una sierra golpea al gato.

---

## Configuración y Dependencias

1. **Requisitos:**
   - Unity versión `2020.3` o superior.
   - Dispositivo Android o iOS para pruebas móviles.

2. **Configuración para móviles:**
   - Ve a **File > Build Settings**.
   - Selecciona la plataforma deseada (**Android** o **iOS**) y haz clic en "Switch Platform".
   - Asegúrate de configurar correctamente el **Player Settings** (nombre del paquete, icono, etc.).

3. **Scripts Clave:**
   - **PlayerController.cs:** Controla el movimiento del gato.
   - **Obstaculo.cs:** Maneja las sierras, su rotación y colisiones.
   - **GeneradorSierras.cs:** Genera sierras de manera dinámica.
   - **GameManager.cs:** Gestiona el estado del juego, puntuaciones y reinicio.


