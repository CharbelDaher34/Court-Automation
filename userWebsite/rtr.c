#include <htc.h>
#define byte unsigned char
#define LED0 0x01
#define LED1 0x02
#define LED2 0x04
#define LED3 0b001000
#define LED4 0b010000
#define LED5 0b100000
__CONFIG(0x3fc4);
void init();
byte x10ms, x100ms, x10ms0, x100ms0;
byte ys1, ys2, ys3, ys4, ys5, ys0, V1, V2, V3, V4, V5, V0;
main()
{
    init();
    RA0 = RA1 = RA2 = RA3 = RA4 = RA5 = 0;
    do
    {
        if (RA1 == 1)
        {
            V1 = 1;
            RC1 = 1;

            x10ms = 0;
            x100ms = 0;
            T0IF = 1;
        }
        if (RA2 == 1)
        {
            V2 = 1;
        }
        if (RA3 == 1)
        {
            V3 = 1;
        }
        if (RA4 == 1)
        {
            V4 = 1;
        }
        if (RA5 == 1)
        {
            V5 = 1;
        }
        if (RA0 == 1)
        {
            V0 = 1;
            RC0 = 1;

            x10ms0 = 0;
            x100ms0 = 0;
            T0IF = 1;
        }

    } while (1);
}

void interrupt ISR()
{
    if (T0IF && T0IE) // Timer0 interrupt occurred and interrupt is enabled
    {

        _delay(0);
        T0IF = 0;
        // asm(" nop");
        TMR0 = 100;
        if (V1 == 1)
        {
            x10ms++;
            if (x10ms == 10)
            {
                x10ms = 0;
                x100ms++;

                if (x100ms == 10)
                {
                    x100ms = 0;
                    if (ys1 != 0)
                        ys1--;

                    if (ys1 == 0)
                    {
                        ys1 = 3;
                        RC1 = 0;
                        V1 = 0;
                        x100ms0 = 0;
                        x100ms0 = 0;
                    }
                }
            }
        }
        if (V0 == 1)
        {
            x10ms0++;
            if (x10ms0 == 10)
            {
                x10ms0 = 0;
                x100ms0++;

                if (x100ms0 == 10)
                {
                    x100ms0 = 0;
                    if (ys0 != 0)
                        ys0--;

                    if (ys0 == 0)
                    {
                        ys0 = 2;
                        RC0 = 0;
                        V0 = 0;
                        x100ms0 = 0;
                        x100ms0++;
                    }
                }
            }
        }
    }
}

void init()
{

    ANSEL = 0;
    TRISC = 0;
    OPTION_REG = 0x05; // /64
    WPUA = 0xff;
    CMCON = 7;
    T0IE = GIE = RAIE = 1;
    IOCA = 0b00111111;
    x10ms = x100ms = x100ms0 = x10ms0 = 0;
    TMR0 = 100;
    PORTC = 0;
    ys0 = 2;
    ys1 = 3;
    ys2 = 5;
    ys3 = 6;
    ys4 = 7;
    ys5 = 10;
    PORTA = 0; // bug Rpullups PROTEUS
}