
# 近似公式

### BCH 近似

$$
\ln\left[ \exp\left( \Delta\vec\phi^\wedge \right) \exp\left( \vec\phi^\wedge \right) \right]^\vee \approx
\boldsymbol{J}_l \left( \vec\phi \right)^{-1} \Delta\vec\phi + \vec\phi
$$

$$
\ln\left[ \exp\left( \vec\phi^\wedge \right) \exp\left( \Delta\vec\phi^\wedge \right) \right]^\vee \approx
\boldsymbol{J}_r \left( \vec\phi \right)^{-1} \Delta\vec\phi + \vec\phi
$$

### 近似雅克比

$$
\boldsymbol{J}_l = \frac{\sin\theta}{\theta} \boldsymbol{I} +
\left( 1 - \frac{\sin\theta}{\theta} \right) \vec{a}\vec{a}^T +
\frac{1 - \cos\theta}{\theta} \vec{a}^\wedge
$$

$$
\boldsymbol{J}_l^{-1} = \frac{\theta}{2} \cot\frac{\theta}{2} \boldsymbol{I} +
\left( 1 - \frac{\theta}{2} \cot\frac{\theta}{2} \right) \vec{a}\vec{a}^T -
\frac{\theta}{2} \vec{a}^\wedge
$$

$$
\boldsymbol{J}_r \left(\vec\phi\right) = \boldsymbol{J}_l \left(-\vec\phi\right)
$$

### 意义

$$
\Delta\boldsymbol{R} \cdot \boldsymbol{R} =
\exp\left( \Delta\vec\phi^\wedge \right) \exp\left( \vec\phi^\wedge \right) =
\exp\left\{ \left[ \boldsymbol{J}_l \left( \vec\phi \right)^{-1} \Delta\vec\phi + \vec\phi \right]^\wedge \right\}
$$

$$
\exp\left[\left( \vec\phi + \Delta\vec\phi \right)^\wedge\right] =
\exp\left[ \left( \boldsymbol{J}_l \Delta\vec\phi \right)^\wedge \right] \exp\left(\vec\phi^\wedge\right) =
\exp\left(\vec\phi^\wedge\right) \exp\left[ \left( \boldsymbol{J}_r \Delta\vec\phi \right)^\wedge \right]
$$

### $SE(3)$

$$
\exp\left( \Delta\vec\xi^\wedge \right) \exp\left( \vec\xi^\wedge \right) \approx
\exp\left[ \left( \mathcal{J}_l^{-1} \Delta\vec\xi + \vec\xi \right)^\wedge \right]
$$

$$
\exp\left( \vec\xi^\wedge \right) \exp\left( \Delta\vec\xi^\wedge \right) \approx
\exp\left[ \left( \mathcal{J}_r^{-1} \Delta\vec\xi + \vec\xi \right)^\wedge \right]
$$
