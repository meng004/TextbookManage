/*  

 * 格式化金额，  

 * num为十进制Number类型的原值，  

 * n为保留的小数位数  

 * return 格式化后的金额字符串  

 */

function fMoney(num, n) {
    var numStr = num.toString(),

        pointIndex = numStr.indexOf('.'),

        beforePoint,

        afterPoint;

    if (pointIndex < 0) {

        beforePoint = numStr;

        afterPoint = '';

    } else {

        beforePoint = numStr.substring(0, pointIndex);

        if (typeof n == 'undefined') {
            afterPoint = numStr.substring(pointIndex);

        } else {

            afterPoint = numStr.substring(pointIndex, pointIndex + n + 1);
        }

    }
    var re = /(-?\d+)(\d{3})/;

    while (re.test(beforePoint)) {
        beforePoint = beforePoint.replace(re, "$1,$2");
    }
    return beforePoint + afterPoint;
}
