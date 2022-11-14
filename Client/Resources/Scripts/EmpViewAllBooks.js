let allBooks = []
const baseUrl = 'https://countriesnow.space/api/v0.1/countries/population/cities'

const app = document.getElementById('allCities');


function handleOnLoad(){
    let table = createTable();
    app.appendChild(table);

    GetAllCities();
}

function GetAllCities(){
    let allCitiesTable = document.getElementById('allCitiesTable');
    let count = 0;
    fetch(baseUrl).then(function(response){
        return response.json();

    }).then(function(json){
        allCities = json;
        console.log(allCities)
        console.log(allCities.data[0])
        console.log(allCities.data[0].populationCounts[0])
        allCities.data.forEach(city=> {
            let tableBody = document.getElementById('allCitiesTableBody');
            let tr = document.createElement('TR');
            tableBody.appendChild(tr);

            let td1 = document.createElement('TD');
            td1.width = 300;
            td1.appendChild(document.createTextNode(`${city.city}`));
            tr.appendChild(td1);

            let td2 = document.createElement('TD');
            td2.width = 150;
            td2.appendChild(document.createTextNode(`${city.country}`));
            tr.appendChild(td2);

            let td3 = document.createElement('TD');
            td3.width = 150;
            city = allCities.data[count].populationCounts[0]
            td3.appendChild(document.createTextNode(`${city.value}`))
            tr.appendChild(td3);
            count++;
        })
        
    })
}


    function createTable()
    {
    let table = document.createElement('TABLE');
    table.id = 'allCitiesTable';
    table.border = '1';
    let tableBody = document.createElement('TBODY');
    tableBody.id = 'allCitiesTableBody';
    table.appendChild(tableBody);
    
    
    let tr = document.createElement('TR');
    tableBody.appendChild(tr);
    
    let th1 = document.createElement('TH');
    th1.width = 150;
    th1.appendChild(document.createTextNode('City'));
    tr.appendChild(th1);
    
    let th2 = document.createElement('TH');
    th2.width = 300;
    th2.appendChild(document.createTextNode('Country'));
    tr.appendChild(th2);
    
    let th3 = document.createElement('TH');
    th3.width = 150;
    th3.appendChild(document.createTextNode('Population'));
    tr.appendChild(th3);
    
    return table;
    }