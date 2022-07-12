# HerokuCoreAPI
Root URL:
```
https://democoreapi.herokuapp.com/api/
```
Get: All People
```
https://democoreapi.herokuapp.com/api/people/all
```
Get: One People
```
https://democoreapi.herokuapp.com/api/people?auth={AUTH}&id={ID}
```
Get: All ResultIds
```
https://democoreapi.herokuapp.com/api/resultIds?auth={AUTH}}&start={yyy-MM-dd}&{yyy-MM-dd}
```
Get: Single Result
```
https://democoreapi.herokuapp.com/api/results?auth={AUTH}&resultIds={ResultIds}
```
Post: Mark A result
```
https://democoreapi.herokuapp.com/api/results?resultIds={ResultIds}&auth={AUTH}&isMarked={bool}
```