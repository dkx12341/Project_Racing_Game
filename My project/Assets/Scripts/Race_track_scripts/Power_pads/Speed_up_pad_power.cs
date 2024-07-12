using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_up_pad_power : Pad_power
{
    // Start is called before the first frame update

    public new float power_time = 5;

    public float speed_up_power = 2;
    public override void apply_pad_power(Collider other)
    {
        GameObject players_car = other.gameObject;
        Player_car_controller engine = players_car.GetComponentInChildren<Player_car_controller>();

        multiply_engine_power(engine);

        Waiter.Wait(power_time, () =>
        {
            divide_engine_power(engine);
        });
    }


    private void divide_engine_power(Player_car_controller engine)
    {
        engine.engine_power = engine.engine_power / speed_up_power;
        engine.max_speed = engine.max_speed / speed_up_power;
    }

    private void multiply_engine_power(Player_car_controller engine)
    {
        engine.engine_power = engine.engine_power * speed_up_power;
        engine.max_speed = engine.max_speed * speed_up_power;

    }
}
