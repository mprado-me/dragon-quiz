using UnityEngine;
using System.Collections;

public class MathQuestionGenerator {

    public MathQuestionGenerator() {

    }

    public Question GetNew() {
        int x = Random.Range(0, 10 + 1);

        int a = Random.Range(0, 10 + 1);
        int b = Random.Range(0, 10 + 1);
        int c = Random.Range(0, 10 + 1);
        int d = Random.Range(1, 3 + 1);
        if(Random.Range(0f, 1f) < 0.5f)
            d *= -1;

        float A = Random.Range(0, 50 + 1) / 10f;
        float B = Random.Range(0, 50 + 1) / 10f;
        float C = Random.Range(1, 3 + 1) / 10f;
        if(Random.Range(0f, 1f) < 0.5f)
            C *= -1;

        switch(Random.Range(0, 16)) {
            case 0:
                return new Question(
                    "x + " + a + " = " + b,
                    "x = " + (b - a),
                    "x = " + (b - a + d)
                    );
            case 1:
                return new Question(
                    a + " + x = " + b,
                    "x = " + (b - a),
                    "x = " + (b - a + d)
                    );
            case 2:
                return new Question(
                    "x - " + a + " = " + b,
                    "x = " + (b + a),
                    "x = " + (b + a + d)
                    );
            case 3:
                return new Question(
                    a + " - x = " + b,
                    "x = " + (a - b),
                    "x = " + (a - b + d)
                    );
            case 4:
                return new Question(
                    a + " + " + b,
                    "" + (a + b),
                    "" + (a + b + d)
                    );
            case 5:
                return new Question(
                    a + " - " + b,
                    "" + (a - b),
                    "" + (a - b + d)
                    );
            case 6:
                return new Question(
                    a + " * " + b,
                    "" + (a * b),
                    "" + ((a * b) + d)
                    );
            case 7:
                return new Question(
                    a + " + " + b + " + " + c,
                    "" + (a + b + c),
                    "" + (a + b + c + d)
                    );
            case 8:
                return new Question(
                    a + " + " + b + " - " + c,
                    "" + (a + b - c),
                    "" + (a + b - c + d)
                    );
            case 9:
                return new Question(
                    a + " - " + b + " + " + c,
                    "" + (a - b + c),
                    "" + (a - b + c + d)
                    );
            case 10:
                return new Question(
                    a + " - " + b + " - " + c,
                    "" + (a - b - c),
                    "" + (a - b - c + d)
                    );
            case 11:
                return new Question(
                    "x² = " + x * x,
                    "x = +-" + x,
                    "x = +-" + Mathf.Abs(x + b)
                    );
            case 12:
                return new Question(
                    "x² + " + a + " = " + (x * x + a),
                    "x = +-" + x,
                    "x = +-" + Mathf.Abs(x + b)
                    );
            case 13:
                return new Question(
                    A + " + " + B,
                    "" + (A + B),
                    "" + (A + B + C)
                    );
            case 14:
                return new Question(
                    A + " - " + B,
                    "" + (A - B),
                    "" + (A - B + C)
                    );
            case 15:
                return new Question(
                    A + " * " + B,
                    "" + (A * B),
                    "" + ((A * B) + C)
                    );
        }
        return null;
    }
}
