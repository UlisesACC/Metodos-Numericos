# WindowsFormsApp1
````````

# Métodos Numéricos - Aplicación Windows Forms

Una aplicación educativa que implementa cinco métodos numéricos clásicos para encontrar raíces de ecuaciones no lineales.

## ?? Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Características](#características)
- [Instalación](#instalación)
- [Métodos Implementados](#métodos-implementados)
  - [1. Bisección](#1-bisección)
  - [2. Secante](#2-secante)
  - [3. Falsa Posición](#3-falsa-posición)
  - [4. Newton-Raphson](#4-newton-raphson)
  - [5. Müller](#5-müller)
- [Uso](#uso)
- [Requisitos](#requisitos)

---

## ?? Descripción General

Esta aplicación proporciona una interfaz gráfica intuitiva para calcular raíces de ecuaciones utilizando diferentes métodos numéricos. Cada método tiene su propia pantalla con entrada de parámetros, validación de datos y visualización de resultados iterativos.

---

## ? Características

- ? Interfaz profesional con barra lateral de navegación
- ? Teclado matemático visual para insertar ecuaciones
- ? Soporta funciones trigonométricas: sin(x), cos(x), tan(x)
- ? Soporta funciones matemáticas: sqrt(x), log(x), ln(x), exp(x), abs(x)
- ? Tabla de resultados iterativos detallada
- ? Validación completa de entradas
- ? Mensajes de error descriptivos
- ? Soporte para constantes matemáticas: ? (PI), e

---

## ?? Instalación

1. Clonar el repositorio:
```bash
git clone https://github.com/UlisesACC/Metodos-Numericos.git
cd Metodos-Numericos/WindowsFormsApp1
```

2. Abrir en Visual Studio:
   - Visual Studio 2019 o superior
   - .NET Framework 4.7.2

3. Compilar y ejecutar:
```bash
dotnet build
dotnet run
```

---

## ?? Métodos Implementados

### 1. Bisección

**Descripción**: Método que divide repetidamente un intervalo por la mitad para localizar la raíz.

#### Ecuación Fundamental

```
c = (a + b) / 2
```

Donde:
- **a** = límite inferior del intervalo
- **b** = límite superior del intervalo
- **c** = punto medio (aproximación de la raíz)

#### Condición de Convergencia

```
f(a) * f(b) < 0
```

Es decir, la función debe cambiar de signo en el intervalo [a, b].

#### Criterio de Error

```
Error = |b - a| / 2
```

#### Algoritmo en Pseudocódigo

```
ALGORITMO Bisección(f, a, b, tolerancia, maxIteraciones)
    ENTRADA: 
        - f: función a resolver
        - a, b: intervalo inicial [a, b]
        - tolerancia: criterio de convergencia
        - maxIteraciones: máximo de iteraciones permitidas
    
    SALIDA: raíz aproximada x
    
    INICIO
        iteración ? 0
        error ? |b - a|
        
        // Validar que hay cambio de signo
        SI f(a) * f(b) >= 0 ENTONCES
            RETORNAR "Error: No hay cambio de signo"
        FIN SI
        
        MIENTRAS error > tolerancia Y iteración < maxIteraciones HACER
            c ? (a + b) / 2
            fc ? f(c)
            fa ? f(a)
            error ? |b - a| / 2
            
            // Guardar resultado de la iteración
            GUARDAR(iteración, a, b, c, fc, error)
            
            // Elegir subintervalo
            SI fa * fc < 0 ENTONCES
                b ? c          // La raíz está en [a, c]
            SINO
                a ? c          // La raíz está en [c, b]
            FIN SI
            
            iteración ? iteración + 1
        FIN MIENTRAS
        
        raíz ? (a + b) / 2
        RETORNAR raíz
    FIN
```

---

### 2. Secante

**Descripción**: Método que utiliza la línea secante que pasa por dos puntos consecutivos de la función.

#### Ecuación Fundamental

```
x_n = x_{n-1} - f(x_{n-1}) * (x_{n-1} - x_{n-2}) / (f(x_{n-1}) - f(x_{n-2}))
```

Donde:
- **x_{n-2}** = aproximación anterior a la anterior
- **x_{n-1}** = aproximación anterior
- **x_n** = nueva aproximación
- **f(x_{n-1})** = valor de la función en x_{n-1}
- **f(x_{n-2})** = valor de la función en x_{n-2}

#### Criterio de Error

```
Error = |x_n - x_{n-1}|
```

#### Algoritmo en Pseudocódigo

```
ALGORITMO Secante(f, x0, x1, tolerancia, maxIteraciones)
    ENTRADA:
        - f: función a resolver
        - x0: primera aproximación inicial
        - x1: segunda aproximación inicial
        - tolerancia: criterio de convergencia
        - maxIteraciones: máximo de iteraciones permitidas
    
    SALIDA: raíz aproximada x
    
    INICIO
        iteración ? 0
        error ? infinito
        
        MIENTRAS error > tolerancia Y iteración < maxIteraciones HACER
            fx0 ? f(x0)
            fx1 ? f(x1)
            
            // Verificar que el denominador no sea cero
            SI |fx1 - fx0| < 1e-10 ENTONCES
                RETORNAR "Error: Denominador muy cercano a cero"
            FIN SI
            
            // Calcular nueva aproximación usando la fórmula de la secante
            x2 ? x1 - fx1 * (x1 - x0) / (fx1 - fx0)
            error ? |x2 - x1|
            
            // Guardar resultado de la iteración
            GUARDAR(iteración, x0, x1, fx1, x2, error)
            
            // Actualizar aproximaciones
            x0 ? x1
            x1 ? x2
            iteración ? iteración + 1
        FIN MIENTRAS
        
        RETORNAR x1
    FIN
```

---

### 3. Falsa Posición

**Descripción**: Similar a bisección pero usa interpolación lineal en lugar de punto medio.

#### Ecuación Fundamental

```
c = a - f(a) * (b - a) / (f(b) - f(a))
```

Donde:
- **a** = límite inferior del intervalo
- **b** = límite superior del intervalo
- **c** = aproximación por interpolación lineal
- **f(a)**, **f(b)** = valores de la función en los extremos

#### Condición de Convergencia

```
f(a) * f(b) < 0
```

(Igual que bisección)

#### Criterio de Error

```
Error = |b - a|
```

#### Algoritmo en Pseudocódigo

```
ALGORITMO FalsaPosición(f, a, b, tolerancia, maxIteraciones)
    ENTRADA:
        - f: función a resolver
        - a, b: intervalo inicial [a, b]
        - tolerancia: criterio de convergencia
        - maxIteraciones: máximo de iteraciones permitidas
    
    SALIDA: raíz aproximada x
    
    INICIO
        iteración ? 0
        error ? infinito
        
        // Validar que hay cambio de signo
        fa ? f(a)
        fb ? f(b)
        
        SI fa * fb >= 0 ENTONCES
            RETORNAR "Error: No hay cambio de signo"
        FIN SI
        
        MIENTRAS error > tolerancia Y iteración < maxIteraciones HACER
            fa ? f(a)
            fb ? f(b)
            
            // Calcular punto de intersección de la recta con eje x
            c ? a - fa * (b - a) / (fb - fa)
            fc ? f(c)
            
            error ? |b - a|
            
            // Guardar resultado de la iteración
            GUARDAR(iteración, a, b, c, fc, error)
            
            // Elegir subintervalo
            SI fa * fc < 0 ENTONCES
                b ? c          // La raíz está en [a, c]
            SINO
                a ? c          // La raíz está en [c, b]
            FIN SI
            
            iteración ? iteración + 1
        FIN MIENTRAS
        
        raíz ? (a + b) / 2
        RETORNAR raíz
    FIN
```

---

### 4. Newton-Raphson

**Descripción**: Método que utiliza la derivada de la función para encontrar la raíz.

#### Ecuación Fundamental

```
x_{n+1} = x_n - f(x_n) / f'(x_n)
```

Donde:
- **x_n** = aproximación actual
- **x_{n+1}** = nueva aproximación
- **f(x_n)** = valor de la función en x_n
- **f'(x_n)** = derivada de f evaluada en x_n

#### Criterio de Error

```
Error = |x_{n+1} - x_n|
```

#### Algoritmo en Pseudocódigo

```
ALGORITMO NewtonRaphson(f, f', x0, tolerancia, maxIteraciones)
    ENTRADA:
        - f: función a resolver
        - f': derivada de f
        - x0: aproximación inicial
        - tolerancia: criterio de convergencia
        - maxIteraciones: máximo de iteraciones permitidas
    
    SALIDA: raíz aproximada x
    
    INICIO
        iteración ? 0
        error ? infinito
        x ? x0
        
        MIENTRAS error > tolerancia Y iteración < maxIteraciones HACER
            fx ? f(x)
            fpx ? f'(x)
            
            // Verificar que la derivada no sea cero
            SI |fpx| < 1e-10 ENTONCES
                RETORNAR "Error: Derivada muy cercana a cero"
            FIN SI
            
            // Calcular nueva aproximación
            xNext ? x - fx / fpx
            error ? |xNext - x|
            
            // Guardar resultado de la iteración
            GUARDAR(iteración, x, fx, fpx, xNext, error)
            
            x ? xNext
            iteración ? iteración + 1
        FIN MIENTRAS
        
        RETORNAR x
    FIN
```

---

### 5. Müller

**Descripción**: Método que aproxima la función mediante una parábola usando tres puntos.

#### Ecuaciones Fundamentales

**Diferencias Divididas:**

```
h_0 = x_1 - x_0
h_1 = x_2 - x_1
delta_0 = (f(x_1) - f(x_0)) / h_0
delta_1 = (f(x_2) - f(x_1)) / h_1
a = (delta_1 - delta_0) / (h_1 + h_0)
```

**Coeficientes del Polinomio:**

```
b = delta_1 + h_1 * a
c = f(x_2)
```

**Discriminante:**

```
discriminante = b² - 4*a*c
```

**Nueva Aproximación:**

```
x_3 = x_2 - (2*c) / (b ± sqrt(b² - 4*a*c))
```

Se elige el signo que da mayor magnitud en el denominador.

#### Criterio de Error

```
Error = |x_3 - x_2|
```

#### Algoritmo en Pseudocódigo

```
ALGORITMO Müller(f, x0, x1, x2, tolerancia, maxIteraciones)
    ENTRADA:
        - f: función a resolver
        - x0, x1, x2: tres aproximaciones iniciales
        - tolerancia: criterio de convergencia
        - maxIteraciones: máximo de iteraciones permitidas
    
    SALIDA: raíz aproximada x
    
    INICIO
        iteración ? 0
        error ? infinito
        
        MIENTRAS error > tolerancia Y iteración < maxIteraciones HACER
            // Evaluar la función en los tres puntos
            fx0 ? f(x0)
            fx1 ? f(x1)
            fx2 ? f(x2)
            
            // Calcular diferencias divididas
            h0 ? x1 - x0
            h1 ? x2 - x1
            delta0 ? (fx1 - fx0) / h0
            delta1 ? (fx2 - fx1) / h1
            
            // Coeficientes del polinomio cuadrático
            a ? (delta1 - delta0) / (h1 + h0)
            b ? delta1 + h1 * a
            c ? fx2
            
            // Calcular discriminante
            discriminante ? b² - 4*a*c
            
            SI |a| < 1e-10 ENTONCES
                RETORNAR "Error: Coeficiente 'a' muy cercano a cero"
            FIN SI
            
            // Elegir el denominador con mayor valor absoluto
            denominador1 ? b + sqrt(discriminante)
            denominador2 ? b - sqrt(discriminante)
            
            SI |denominador1| > |denominador2| ENTONCES
                denominador ? denominador1
            SINO
                denominador ? denominador2
            FIN SI
            
            // Calcular nueva aproximación
            x3 ? x2 - (2*c) / denominador
            error ? |x3 - x2|
            
            // Guardar resultado de la iteración
            GUARDAR(iteración, x0, x1, x2, x3, error)
            
            // Desplazar aproximaciones
            x0 ? x1
            x1 ? x2
            x2 ? x3
            
            iteración ? iteración + 1
        FIN MIENTRAS
        
        RETORNAR x2
    FIN
```

---

## ??? Uso

### Pantalla Principal

1. Al iniciar la aplicación, verá la pantalla de bienvenida
2. Seleccione el método deseado de la barra lateral izquierda

### Ingreso de Datos

Para cada método debe proporcionar:

- **Función f(x)**: La ecuación a resolver
  - Use el botón "?? Insertar Ecuación" para usar el teclado visual
  - Ejemplo: `x^3 - 2*x - 5`

- **Parámetros específicos**:
  - **Bisección/Falsa Posición**: Intervalo [a, b]
  - **Secante**: Dos aproximaciones iniciales (x0, x1)
  - **Newton-Raphson**: Aproximación inicial (x0) y su derivada
  - **Müller**: Tres aproximaciones iniciales (x0, x1, x2)

- **Tolerancia (?)**: Criterio de convergencia (ej: 0.0001)
- **Máximo de Iteraciones**: Límite de pasos permitidos (ej: 100)

### Interpretación de Resultados

La tabla de resultados muestra:

| Columna | Significado |
|---------|------------|
| Iteración | Número del paso |
| a/b/x0/x1 | Aproximaciones actuales |
| c/xn | Nueva aproximación |
| f(c)/f(x) | Valor de la función |
| Error | Error estimado en el paso |

---

## ?? Requisitos

- **Sistema Operativo**: Windows 7 o superior
- **.NET Framework**: 4.7.2 o superior
- **Visual Studio**: 2019 o superior (para compilar)
- **RAM**: 512 MB mínimo
- **Resolución**: 1024x768 mínima

---

## ?? Funciones Soportadas

### Trigonométricas
- `sin(x)` - Seno (radianes)
- `cos(x)` - Coseno (radianes)
- `tan(x)` - Tangente (radianes)

### Matemáticas
- `sqrt(x)` - Raíz cuadrada
- `log(x)` - Logaritmo base 10
- `ln(x)` - Logaritmo natural
- `exp(x)` - Función exponencial
- `abs(x)` - Valor absoluto

### Constantes
- `PI` - Pi (? ? 3.14159...)
- `e` - Número de Euler (e ? 2.71828...)

### Operadores
- `+` - Suma
- `-` - Resta
- `*` - Multiplicación
- `/` - División
- `^` - Potencia (ej: x^2, x^3)
- `( )` - Paréntesis

---

## ?? Ejemplos de Uso

### Ejemplo 1: Encontrar raíz de f(x) = x³ - 2x - 5

**Datos de entrada:**
- Función: `x^3 - 2*x - 5`
- Intervalo (Bisección): [2, 3]
- Tolerancia: 0.0001
- Máx iteraciones: 100

**Resultado esperado:**
- Raíz ? 2.094568

### Ejemplo 2: Resolver f(x) = sin(x) - x/2

**Datos de entrada:**
- Función: `sin(x) - x/2`
- Aproximación inicial (Newton): 2.0
- Derivada: `cos(x) - 0.5`
- Tolerancia: 0.00001
- Máx iteraciones: 50

**Resultado esperado:**
- Raíz ? 1.895494

---

## ?? Contribuciones

Las contribuciones son bienvenidas. Para cambios importantes:

1. Haga un fork del repositorio
2. Cree una rama para su feature (`git checkout -b feature/AmazingFeature`)
3. Commit sus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abra un Pull Request

---

## ?? Licencia

Este proyecto está bajo la licencia MIT. Ver el archivo `LICENSE` para más detalles.

---

## ????? Autor

**Ulises Acosta Cervantes**

- GitHub: [@UlisesACC](https://github.com/UlisesACC)
- Institución: ESCOM - IPN

---

## ?? Soporte

Si encuentra algún problema o tiene preguntas:

1. Verifique que está usando .NET Framework 4.7.2
2. Asegúrese de que la función está correctamente escrita
3. Valide que el intervalo [a,b] contiene un cambio de signo (para métodos de intervalo)
4. Abra un issue en el repositorio de GitHub

---

## ?? Referencias Bibliográficas

- Burden, R. L., & Faires, J. D. (2011). *Numerical Analysis* (9th ed.). Brooks/Cole.
- Chapra, S. C., & Canale, R. P. (2015). *Numerical Methods for Engineers* (7th ed.). McGraw-Hill.
- Gerald, C. F., & Wheatley, P. O. (2004). *Applied Numerical Analysis* (7th ed.). Pearson.

---

**Última actualización**: 2024