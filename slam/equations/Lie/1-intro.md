任意选择矩阵 $R$ 在任意时间 $t$ 满足：

$$\boldsymbol R(t) \boldsymbol R(t)^T = \boldsymbol I \tag{1}$$

两边对时间求导：

$$\dot\boldsymbol R(t) \boldsymbol R(t)^T + \boldsymbol R(t) \dot\boldsymbol R(t)^T = \boldsymbol 0 \tag{2}$$

$$\dot\boldsymbol R(t) \boldsymbol R(t)^T = - \left[ \dot\boldsymbol R(t) \boldsymbol R(t)^T \right] ^T \tag{3}$$

$\dot\boldsymbol R(t) \boldsymbol R(t)^T$ 是**反对称矩阵**，存在三维向量 $\vec\phi(t)$，满足：

$$\dot\boldsymbol R(t) \boldsymbol R(t)^T = \vec\phi(t)^\wedge$$

两边右乘 $R(t)$，

$$\dot\boldsymbol R(t) = \vec\phi(t)^\wedge \boldsymbol R(t) = \left[ \begin{array} { c c c } { 0 } & { - \phi_3 } & { \phi_2 } \\ { \phi_3 } & { 0 } & { - \phi_1 } \\ { - \phi_2 } & { \phi_1 } & { 0 } \end{array} \right] \boldsymbol R(t)$$

设 $t_0 = 0$ 时 $\boldsymbol R(0) = \boldsymbol I$，在 $0$ 附近泰勒展开：

$$\boldsymbol R(t) \approx \boldsymbol R \left( t_0 \right) + \dot\boldsymbol R \left( t_0 \right) \left( t - t_0 \right) = \boldsymbol I + \vec\phi \left( t_0 \right) ^\wedge t$$
