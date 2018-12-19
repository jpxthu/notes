# 三维旋转

### 李群

$$
SO(3) = \left\{
    \boldsymbol{R} \in \Bbb{R} ^ {3 \times 3}, {\ }
    \boldsymbol{RR}^T = \boldsymbol{I}, {\ }
    \det( \boldsymbol{R} ) = 1
\right\}
$$

$$
\vec{q} =
\left[ \begin{array} {c} q_{\omega} \\ q_1 \\ q_2 \\ q_3 \end{array} \right] =
\left[ \begin{array} {c} \cos\theta/2 \\ \vec{a} \sin\theta/2 \end{array} \right]
$$

### 李代数

$$
\frak{so}(3) = \left\{
    \vec\phi \in \Bbb{R}^3, {\ }
    \bold{\Phi} = \vec\phi^\wedge = \left[ \begin{array} {ccc}
        { 0 } & { - \phi_3 } & { \phi_2 } \\
        { \phi_3 } & { 0 } & { - \phi_1 } \\
        { - \phi_2 } & { \phi_1 } & { 0 }
    \end{array} \right] \in \Bbb{R}^{3 \times 3} \right\}
$$

### 指数映射

$$
\exp\left( \vec\phi^\wedge \right) =
\exp\left( \theta\vec{a}^\wedge \right) =
\cos\theta\boldsymbol{I} +
\left( 1-\cos\theta \right) \vec{a}\vec{a}^T +
\left( \sin\theta \right)\vec{a}^\wedge
$$

$$
\boldsymbol{R} = \left[ \begin{array} {ccc}
    q_{\omega}^2 + q_1^2 - q_2^2 - q_3^2 & 2q_1q_2 - 2q_{\omega}q_3 & 2q_1q_3 + 2q_{\omega}q_2 \\
    2q_1q_2 + 2q_{\omega}q_3 & q_{\omega}^2 - q_1^2 + q_2^2 - q_3^2 & 2q_2q_3 - 2q_{\omega}q_1 \\
    2q_1q_3 - 2q_{\omega}q_2 & 2q_2q_3 + 2q_{\omega}q_1 & q_{\omega}^2 - q_1^2 - q_2^2 + q_3^2
\end{array} \right]
$$

### 对数映射

$$
\theta = \arccos \cfrac{tr \left( \boldsymbol{R} \right) - 1}{2}, {\ }
\boldsymbol{R}\vec{a} = \vec{a}
$$

# 三维变换

### 李群

$$
SE(3) = \left\{
    \boldsymbol{T} = \left[ \begin{array} {cc}
        \boldsymbol{R} & \vec{t} \\
        \vec{0}^T & 1
    \end{array} \right] \in \Bbb{R}^{4\times4}, {\ }
    \boldsymbol{R} \in SO(3), {\ }
    \vec{t} \in \Bbb{R}^3
\right\}
$$

### 李代数

$$
\frak{se}(3) = \left\{
    \vec\xi = \left[ \begin{array} {c} \vec\rho \\ \vec\phi \end{array} \right] \in \Bbb{R}^6, {\ }
    \vec\xi^\wedge = \left[ \begin{array} {cc}
        \vec\phi^\wedge & \vec\rho \\
        \vec{0}^T & 0
    \end{array} \right], {\ }
    \vec\rho \in \Bbb{R}^3, {\ }
    \vec\phi \in \frak{so}(3)
\right\}
$$

### 指数映射

$$
\exp \left( \vec\xi^\wedge \right) = \left[ \begin{array} {cc}
    \exp \left( \vec\phi^\wedge \right) & \boldsymbol{J} \vec\rho \\
    \vec{0}^T & 1
\end{array} \right]
$$

$$
\boldsymbol{J} =
    \frac{\sin\theta}{\theta} \boldsymbol{I} +
    \left( 1 - \frac{\sin\theta}{\theta} \right) \vec{a}\vec{a}^T +
    \frac{1-\cos\theta}{\theta} \vec{a}^\wedge
$$

### 对数映射

$$
\theta = \arccos \cfrac{tr \left( \boldsymbol{R} \right) - 1}{2}, {\ }
\boldsymbol{R}\vec{a} = \vec{a}, {\ }
\vec{t} = \boldsymbol{J} \vec{\rho}
$$
