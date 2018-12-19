# 求导

### 优化问题

三维点到观测

$$ \vec{z} = \boldsymbol{T} \vec{p} + \vec\omega $$

误差

$$ \vec{e} = \vec{z} - \boldsymbol{T} \vec{p} $$

误差最小化

$$
\min_\boldsymbol{T} \sum_i \left\| \vec{z}_i - \boldsymbol{T}\vec{p}_i \right\|_2^2
$$

### 求导

$$
\begin{aligned}
    \frac{\partial\left[ \exp\left(\vec\phi^\wedge\right) \vec{p} \right]}{\partial\vec\phi}
    & = \lim_{\delta\vec\phi \rightarrow 0} \frac{\exp\left[ \left(\vec\phi+\delta\vec\phi\right)^\wedge \right]\vec{p} - \exp\left(\vec\phi^\wedge\right)\vec{p}}{\delta\vec\phi} \\
    & = \lim_{\delta\vec\phi \rightarrow 0} \frac{\exp\left[ \left(\boldsymbol{J}_l \delta\vec\phi\right)^\wedge \right] \exp\left(\vec\phi^\wedge\right) \vec{p} - \exp\left(\vec\phi^\wedge\right)\vec{p}}{\delta\vec\phi} \\
    & \approx \lim_{\delta\vec\phi \rightarrow 0} \frac{\left[ \boldsymbol{I} + \left(\boldsymbol{J}_l \delta\vec\phi\right)^\wedge \right] \exp\left(\vec\phi^\wedge\right) \vec{p} - \exp\left(\vec\phi^\wedge\right)\vec{p}}{\delta\vec\phi} \\
    & = \lim_{\delta\vec\phi \rightarrow 0} \frac{- \left[ \exp\left(\vec\phi^\wedge\right) \vec{p} \right]^\wedge \boldsymbol{J}_l \delta\vec\phi }{\delta\vec\phi} \\
    & = - \left( \boldsymbol{R}\vec{p} \right)^\wedge \boldsymbol{J}_l
\end{aligned}
$$

对左扰动 $\Delta\boldsymbol{R}$（李代数 $\vec\varphi$）

$$
\begin{aligned}
    \frac{\partial\left( \boldsymbol{R}\vec{p} \right)}{\partial\vec\varphi}
    & = \lim_{\vec\varphi \rightarrow 0} \frac{ \exp\left(\vec\varphi^\wedge\right) \exp\left(\vec\phi^\wedge\right) \vec{p} - \exp\left(\vec\phi^\wedge\right) \vec{p} }{\vec\varphi} \\
    & \approx \lim_{\vec\varphi \rightarrow 0} \frac{ \left(1+\vec\varphi^\wedge\right) \exp\left(\vec\phi^\wedge\right) \vec{p} - \exp\left(\vec\phi^\wedge\right) \vec{p} }{\vec\varphi} \\
    & = \lim_{\vec\varphi \rightarrow 0} \frac{ \vec\varphi^\wedge \boldsymbol{R} \vec{p} }{\vec\varphi} \\
    & = \lim_{\vec\varphi \rightarrow 0} \frac{ -\left( \boldsymbol{R} \vec{p} \right) ^\wedge \vec\varphi }{\vec\varphi} \\
    & = -\left( \boldsymbol{R} \vec{p} \right)
\end{aligned}
$$

在 $SE(3)$ 上给 $\boldsymbol{T}$ 一个左扰动 $\Delta\boldsymbol{R} = \exp\left(\delta\vec\xi^\wedge\right)$，扰动项李代数 $\delta\vec\xi = \left[ \delta\vec\rho, \delta\vec\phi \right]^T$

$$
\begin{aligned}
    \frac{\partial\left(\boldsymbol{T}\vec{p}\right)}{\partial\delta\vec\xi}
    & = \lim_{\delta\vec\xi \rightarrow 0} \frac{ \exp\left( \delta\vec\xi^\wedge \right) \exp\left( \vec\xi^\wedge \right) \vec{p} - \exp\left( \vec\xi^\wedge \right) \vec{p} }{ \delta\vec\xi } \\
    & \approx \lim_{\delta\vec\xi \rightarrow 0} \frac{ \left( \boldsymbol{I} +\delta\vec\xi^\wedge \right) \exp\left( \vec\xi^\wedge \right) \vec{p} - \exp\left( \vec\xi^\wedge \right) \vec{p} }{ \delta\vec\xi } \\
    & = \lim_{\delta\vec\xi \rightarrow 0} \frac{ \delta\vec\xi^\wedge \exp\left( \vec\xi^\wedge \right) \vec{p} }{ \delta\vec\xi } \\
    & = \lim_{\delta\vec\xi \rightarrow 0} \frac{ \left[\begin{array} { c c }
        \delta\vec\phi^\wedge & \delta\vec\rho \\ \vec{0}^T & 0
    \end{array}\right] \left[\begin{array} { c }
        \boldsymbol{R}\vec{p} + \vec{t} \\ 1
    \end{array}\right] }{ \delta\vec\xi } \\
    & = \lim_{\delta\vec\xi \rightarrow 0} \frac{ \left[\begin{array} { c c }
        \delta\vec\phi^\wedge \left( \boldsymbol{R}\vec{p} + \vec{t} \right) + \delta\vec\rho \\ 0
    \end{array}\right] }{ \delta\vec\xi } \\
    & = \left[\begin{array} { c c }
        \boldsymbol{I} & -\left( \boldsymbol{R}\vec{p} + \vec{t} \right)^\wedge \\ \vec{0}^T & \vec{0}^T
    \end{array}\right]
\end{aligned}
$$
