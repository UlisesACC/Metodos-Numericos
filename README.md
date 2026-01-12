# M�todos Num�ricos - Aplicaci�n Windows Forms

Una aplicaci�n educativa que implementa cinco m�todos num�ricos cl�sicos para encontrar ra�ces de ecuaciones no lineales.

## ?? Tabla de Contenidos

- [Descripci�n General](#descripci�n-general)
- [Caracter�sticas](#caracter�sticas)
- [Instalaci�n](#instalaci�n)
- [M�todos Implementados](#m�todos-implementados)
  - [1. Bisecci�n](#1-bisecci�n)
  - [2. Secante](#2-secante)
  - [3. Falsa Posici�n](#3-falsa-posici�n)
  - [4. Newton-Raphson](#4-newton-raphson)
  - [5. M�ller](#5-m�ller)
- [Uso](#uso)
- [Requisitos](#requisitos)

---

## ?? Descripci�n General

Esta aplicaci�n proporciona una interfaz gr�fica intuitiva para calcular ra�ces de ecuaciones utilizando diferentes m�todos num�ricos. Cada m�todo tiene su propia pantalla con entrada de par�metros, validaci�n de datos y visualizaci�n de resultados iterativos.

---

## ? Caracter�sticas

- ? Interfaz profesional con barra lateral de navegaci�n
- ? Teclado matem�tico visual para insertar ecuaciones
- ? Soporta funciones trigonom�tricas: sin(x), cos(x), tan(x)
- ? Soporta funciones matem�ticas: sqrt(x), log(x), ln(x), exp(x), abs(x)
- ? Tabla de resultados iterativos detallada
- ? Validaci�n completa de entradas
- ? Mensajes de error descriptivos
- ? Soporte para constantes matem�ticas: ? (PI), e

---

## ?? Instalaci�n

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

## ?? M�todos Implementados

### 1. Bisecci�n

**Descripci�n**: M�todo que divide repetidamente un intervalo por la mitad para localizar la ra�z.

#### Ecuaci�n Fundamental

```
c = (a + b) / 2
```

Donde:
- **a** = l�mite inferior del intervalo
- **b** = l�mite superior del intervalo
- **c** = punto medio (aproximaci�n de la ra�z)

#### Condici�n de Convergencia

```
f(a) * f(b) < 0
```

Es decir, la funci�n debe cambiar de signo en el intervalo [a, b].

#### Criterio de Error

```
Error = |b - a| / 2
```

#### Algoritmo en Pseudoc�digo

```
ALGORITMO Bisecci�n(f, a, b, tolerancia, maxIteraciones)
    ENTRADA: 
        - f: funci�n a resolver
        - a, b: intervalo inicial [a, b]
        - tolerancia: criterio de convergencia
        - maxIteraciones: m�ximo de iteraciones permitidas
    
    SALIDA: ra�z aproximada x
    
    INICIO
        iteraci�n ? 0
        error ? |b - a|
        
        // Validar que hay cambio de signo
        SI f(a) * f(b) >= 0 ENTONCES
            RETORNAR "Error: No hay cambio de signo"
        FIN SI
        
        MIENTRAS error > tolerancia Y iteraci�n < maxIteraciones HACER
            c ? (a + b) / 2
            fc ? f(c)
            fa ? f(a)
            error ? |b - a| / 2
            
            // Guardar resultado de la iteraci�n
            GUARDAR(iteraci�n, a, b, c, fc, error)
            
            // Elegir subintervalo
            SI fa * fc < 0 ENTONCES
                b ? c          // La ra�z est� en [a, c]
            SINO
                a ? c          // La ra�z est� en [c, b]
            FIN SI
            
            iteraci�n ? iteraci�n + 1
        FIN MIENTRAS
        
        ra�z ? (a + b) / 2
        RETORNAR ra�z
    FIN
```

---

### 2. Secante

**Descripci�n**: M�todo que utiliza la l�nea secante que pasa por dos puntos consecutivos de la funci�n.

#### Ecuaci�n Fundamental

```
x_n = x_{n-1} - f(x_{n-1}) * (x_{n-1} - x_{n-2}) / (f(x_{n-1}) - f(x_{n-2}))
```

Donde:
- **x_{n-2}** = aproximaci�n anterior a la anterior
- **x_{n-1}** = aproximaci�n anterior
- **x_n** = nueva aproximaci�n
- **f(x_{n-1})** = valor de la funci�n en x_{n-1}
- **f(x_{n-2})** = valor de la funci�n en x_{n-2}

#### Criterio de Error

```
Error = |x_n - x_{n-1}|
```

#### Algoritmo en Pseudoc�digo

```
ALGORITMO Secante(f, x0, x1, tolerancia, maxIteraciones)
    ENTRADA:
        - f: funci�n a resolver
        - x0: primera aproximaci�n inicial
        - x1: segunda aproximaci�n inicial
        - tolerancia: criterio de convergencia
        - maxIteraciones: m�ximo de iteraciones permitidas
    
    SALIDA: ra�z aproximada x
    
    INICIO
        iteraci�n ? 0
        error ? infinito
        
        MIENTRAS error > tolerancia Y iteraci�n < maxIteraciones HACER
            fx0 ? f(x0)
            fx1 ? f(x1)
            
            // Verificar que el denominador no sea cero
            SI |fx1 - fx0| < 1e-10 ENTONCES
                RETORNAR "Error: Denominador muy cercano a cero"
            FIN SI
            
            // Calcular nueva aproximaci�n usando la f�rmula de la secante
            x2 ? x1 - fx1 * (x1 - x0) / (fx1 - fx0)
            error ? |x2 - x1|
            
            // Guardar resultado de la iteraci�n
            GUARDAR(iteraci�n, x0, x1, fx1, x2, error)
            
            // Actualizar aproximaciones
            x0 ? x1
            x1 ? x2
            iteraci�n ? iteraci�n + 1
        FIN MIENTRAS
        
        RETORNAR x1
    FIN
```

---

### 3. Falsa Posici�n

**Descripci�n**: Similar a bisecci�n pero usa interpolaci�n lineal en lugar de punto medio.

#### Ecuaci�n Fundamental

```
c = a - f(a) * (b - a) / (f(b) - f(a))
```

Donde:
- **a** = l�mite inferior del intervalo
- **b** = l�mite superior del intervalo
- **c** = aproximaci�n por interpolaci�n lineal
- **f(a)**, **f(b)** = valores de la funci�n en los extremos

#### Condici�n de Convergencia

```
f(a) * f(b) < 0
```

(Igual que bisecci�n)

#### Criterio de Error

```
Error = |b - a|
```

#### Algoritmo en Pseudoc�digo

```
ALGORITMO FalsaPosici�n(f, a, b, tolerancia, maxIteraciones)
    ENTRADA:
        - f: funci�n a resolver
        - a, b: intervalo inicial [a, b]
        - tolerancia: criterio de convergencia
        - maxIteraciones: m�ximo de iteraciones permitidas
    
    SALIDA: ra�z aproximada x
    
    INICIO
        iteraci�n ? 0
        error ? infinito
        
        // Validar que hay cambio de signo
        fa ? f(a)
        fb ? f(b)
        
        SI fa * fb >= 0 ENTONCES
            RETORNAR "Error: No hay cambio de signo"
        FIN SI
        
        MIENTRAS error > tolerancia Y iteraci�n < maxIteraciones HACER
            fa ? f(a)
            fb ? f(b)
            
            // Calcular punto de intersecci�n de la recta con eje x
            c ? a - fa * (b - a) / (fb - fa)
            fc ? f(c)
            
            error ? |b - a|
            
            // Guardar resultado de la iteraci�n
            GUARDAR(iteraci�n, a, b, c, fc, error)
            
            // Elegir subintervalo
            SI fa * fc < 0 ENTONCES
                b ? c          // La ra�z est� en [a, c]
            SINO
                a ? c          // La ra�z est� en [c, b]
            FIN SI
            
            iteraci�n ? iteraci�n + 1
        FIN MIENTRAS
        
        ra�z ? (a + b) / 2
        RETORNAR ra�z
    FIN
```

---

### 4. Newton-Raphson

**Descripci�n**: M�todo que utiliza la derivada de la funci�n para encontrar la ra�z.

#### Ecuaci�n Fundamental

```
x_{n+1} = x_n - f(x_n) / f'(x_n)
```

Donde:
- **x_n** = aproximaci�n actual
- **x_{n+1}** = nueva aproximaci�n
- **f(x_n)** = valor de la funci�n en x_n
- **f'(x_n)** = derivada de f evaluada en x_n

#### Criterio de Error

```
Error = |x_{n+1} - x_n|
```

#### Algoritmo en Pseudoc�digo

```
ALGORITMO NewtonRaphson(f, f', x0, tolerancia, maxIteraciones)
    ENTRADA:
        - f: funci�n a resolver
        - f': derivada de f
        - x0: aproximaci�n inicial
        - tolerancia: criterio de convergencia
        - maxIteraciones: m�ximo de iteraciones permitidas
    
    SALIDA: ra�z aproximada x
    
    INICIO
        iteraci�n ? 0
        error ? infinito
        x ? x0
        
        MIENTRAS error > tolerancia Y iteraci�n < maxIteraciones HACER
            fx ? f(x)
            fpx ? f'(x)
            
            // Verificar que la derivada no sea cero
            SI |fpx| < 1e-10 ENTONCES
                RETORNAR "Error: Derivada muy cercana a cero"
            FIN SI
            
            // Calcular nueva aproximaci�n
            xNext ? x - fx / fpx
            error ? |xNext - x|
            
            // Guardar resultado de la iteraci�n
            GUARDAR(iteraci�n, x, fx, fpx, xNext, error)
            
            x ? xNext
            iteraci�n ? iteraci�n + 1
        FIN MIENTRAS
        
        RETORNAR x
    FIN
```

---

### 5. M�ller

**Descripci�n**: M�todo que aproxima la funci�n mediante una par�bola usando tres puntos.

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
discriminante = b� - 4*a*c
```

**Nueva Aproximaci�n:**

```
x_3 = x_2 - (2*c) / (b � sqrt(b� - 4*a*c))
```

Se elige el signo que da mayor magnitud en el denominador.

#### Criterio de Error

```
Error = |x_3 - x_2|
```

#### Algoritmo en Pseudoc�digo

```
ALGORITMO M�ller(f, x0, x1, x2, tolerancia, maxIteraciones)
    ENTRADA:
        - f: funci�n a resolver
        - x0, x1, x2: tres aproximaciones iniciales
        - tolerancia: criterio de convergencia
        - maxIteraciones: m�ximo de iteraciones permitidas
    
    SALIDA: ra�z aproximada x
    
    INICIO
        iteraci�n ? 0
        error ? infinito
        
        MIENTRAS error > tolerancia Y iteraci�n < maxIteraciones HACER
            // Evaluar la funci�n en los tres puntos
            fx0 ? f(x0)
            fx1 ? f(x1)
            fx2 ? f(x2)
            
            // Calcular diferencias divididas
            h0 ? x1 - x0
            h1 ? x2 - x1
            delta0 ? (fx1 - fx0) / h0
            delta1 ? (fx2 - fx1) / h1
            
            // Coeficientes del polinomio cuadr�tico
            a ? (delta1 - delta0) / (h1 + h0)
            b ? delta1 + h1 * a
            c ? fx2
            
            // Calcular discriminante
            discriminante ? b� - 4*a*c
            
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
            
            // Calcular nueva aproximaci�n
            x3 ? x2 - (2*c) / denominador
            error ? |x3 - x2|
            
            // Guardar resultado de la iteraci�n
            GUARDAR(iteraci�n, x0, x1, x2, x3, error)
            
            // Desplazar aproximaciones
            x0 ? x1
            x1 ? x2
            x2 ? x3
            
            iteraci�n ? iteraci�n + 1
        FIN MIENTRAS
        
        RETORNAR x2
    FIN
```

---

## ??? Uso

### Pantalla Principal

1. Al iniciar la aplicaci�n, ver� la pantalla de bienvenida
2. Seleccione el m�todo deseado de la barra lateral izquierda

### Ingreso de Datos

Para cada m�todo debe proporcionar:

- **Funci�n f(x)**: La ecuaci�n a resolver
  - Use el bot�n "?? Insertar Ecuaci�n" para usar el teclado visual
  - Ejemplo: `x^3 - 2*x - 5`

- **Par�metros espec�ficos**:
  - **Bisecci�n/Falsa Posici�n**: Intervalo [a, b]
  - **Secante**: Dos aproximaciones iniciales (x0, x1)
  - **Newton-Raphson**: Aproximaci�n inicial (x0) y su derivada
  - **M�ller**: Tres aproximaciones iniciales (x0, x1, x2)

- **Tolerancia (?)**: Criterio de convergencia (ej: 0.0001)
- **M�ximo de Iteraciones**: L�mite de pasos permitidos (ej: 100)

### Interpretaci�n de Resultados

La tabla de resultados muestra:

| Columna | Significado |
|---------|------------|
| Iteraci�n | N�mero del paso |
| a/b/x0/x1 | Aproximaciones actuales |
| c/xn | Nueva aproximaci�n |
| f(c)/f(x) | Valor de la funci�n |
| Error | Error estimado en el paso |

---

## ?? Requisitos

- **Sistema Operativo**: Windows 7 o superior
- **.NET Framework**: 4.7.2 o superior
- **Visual Studio**: 2019 o superior (para compilar)
- **RAM**: 512 MB m�nimo
- **Resoluci�n**: 1024x768 m�nima

---

## ?? Funciones Soportadas

### Trigonom�tricas
- `sin(x)` - Seno (radianes)
- `cos(x)` - Coseno (radianes)
- `tan(x)` - Tangente (radianes)

### Matem�ticas
- `sqrt(x)` - Ra�z cuadrada
- `log(x)` - Logaritmo base 10
- `ln(x)` - Logaritmo natural
- `exp(x)` - Funci�n exponencial
- `abs(x)` - Valor absoluto

### Constantes
- `PI` - Pi (? ? 3.14159...)
- `e` - N�mero de Euler (e ? 2.71828...)

### Operadores
- `+` - Suma
- `-` - Resta
- `*` - Multiplicaci�n
- `/` - Divisi�n
- `^` - Potencia (ej: x^2, x^3)
- `( )` - Par�ntesis

---

## ?? Ejemplos de Uso

### Ejemplo 1: Encontrar ra�z de f(x) = x� - 2x - 5

**Datos de entrada:**
- Funci�n: `x^3 - 2*x - 5`
- Intervalo (Bisecci�n): [2, 3]
- Tolerancia: 0.0001
- M�x iteraciones: 100

**Resultado esperado:**
- Ra�z ? 2.094568

### Ejemplo 2: Resolver f(x) = sin(x) - x/2

**Datos de entrada:**
- Funci�n: `sin(x) - x/2`
- Aproximaci�n inicial (Newton): 2.0
- Derivada: `cos(x) - 0.5`
- Tolerancia: 0.00001
- M�x iteraciones: 50

**Resultado esperado:**
- Ra�z ? 1.895494

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

Este proyecto est� bajo la licencia MIT. Ver el archivo `LICENSE` para m�s detalles.

---

## ????? Autor

**Ulises Acosta Cervantes**

- GitHub: [@UlisesACC](https://github.com/UlisesACC)
- Instituci�n: ESCOM - IPN

---

## ?? Soporte

Si encuentra alg�n problema o tiene preguntas:

1. Verifique que est� usando .NET Framework 4.7.2
2. Aseg�rese de que la funci�n est� correctamente escrita
3. Valide que el intervalo [a,b] contiene un cambio de signo (para m�todos de intervalo)
4. Abra un issue en el repositorio de GitHub

---

## ?? Referencias Bibliogr�ficas

- Burden, R. L., & Faires, J. D. (2011). *Numerical Analysis* (9th ed.). Brooks/Cole.
- Chapra, S. C., & Canale, R. P. (2015). *Numerical Methods for Engineers* (7th ed.). McGraw-Hill.
- Gerald, C. F., & Wheatley, P. O. (2004). *Applied Numerical Analysis* (7th ed.). Pearson.

---

**�ltima actualizaci�n**: 2024