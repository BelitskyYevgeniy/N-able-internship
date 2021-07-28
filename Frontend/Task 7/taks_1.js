function format(obj) {
            if (obj instanceof String || typeof obj === 'string') {
                return "application/text;base64," + btoa(obj).toString();
            }
            if (obj instanceof Array) {
                let str = '[';
                let lim = obj.length - 1;
                for (let i = 0; i < obj.length; ++i) {
                    if (i == lim) {
                        str += obj[i];
                        continue;
                    }
                    str += obj[i] + ', ';
                }
                return str + ']';
            }
            if (typeof obj === 'number' && isFinite(obj)) {
                if (Number.isInteger(obj)) {
                    return obj.toString();
                }
                if (Number(obj) === obj && obj % 1 !== 0) {
                    return obj.toFixed(2).toString();
                }
                return;
            }
            if (Object.prototype.toString.call(obj) == '[object Function]')
                return obj.toString();
            if (obj instanceof RegExp) {
                return obj.toString();
            }
            if (obj instanceof Date) {
                var d = obj,
                    dformat = [d.getMonth() + 1,
                    d.getDate(),
                    d.getFullYear()].join('/') + ' ' +
                        [d.getHours(),
                        d.getMinutes(),
                            d.getSeconds()].join(':');
                return dformat.toString();
            }
            if (obj instanceof Object) {
                let entries = Object.entries(obj);
                let e = [];
                for (let [key, value] of entries) {
                    e.push(format([key, value]));
                }
                return format(e);
            }

        }

        console.log(format("asda"));
        console.log(format(2341));
        console.log(format(325.3124));
        console.log(format([1,2,3]));
        console.log(format({ a: 1, b: 2 }));
        console.log(format(new Date()));
        console.log(format(/regexp/));
        console.log(format(function () { }));