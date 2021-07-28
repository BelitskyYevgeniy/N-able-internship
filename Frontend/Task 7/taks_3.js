    String.prototype.format = function (parameters) {
            let result = this;
            let keys = Object.entries(parameters);
            for (const [key, value] of keys) {
                let regexp = new RegExp('\\{' + key + '\\}');
                result = result.replace(regexp, value);
            }
            return result;
        }
        console.log("{0} {1}".format(["Vadym", "Vinnyk"]));

        console.log("{firstName} {lastName}".format({ firstName: "Vadym", lastName: "Vinnyk" })); // "Vadym Vinnyk"; 
        console.log("{length}".format([1]));
        console.log("{0} {1}".format(['test']));
