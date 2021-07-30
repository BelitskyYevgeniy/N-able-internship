document.querySelectorAll('.b-main-page-news-2');    
    for(let element of elements){
      let el = element.querySelectorAll('div.news-2__main-news-col, div.news-2__secondary-news-col, div.news-2__news-list-col');
      for(let e of el){
          let e_tittle = e.querySelector('h2 a');
          let e_img = e.querySelector('img');
          let e_description = e.querySelector('p'); 
          if(e_tittle !=null)
          {
            console.log('url:' + e_tittle.getAttribute('href')); 
          let e_tit = e_tittle.querySelector('.helpers_show_mobile-small'); 
          if(e_tit != null) e_tittle = e_tit;
           console.log(console.log('tittle: ' + e_tittle.innerHTML)); 
          }; 
          if(e_img != null) 
          {
            console.log('img: '); 
            console.log('%c ', 'font-size: 1000px; background:url('+e_img.getAttribute('src').toString() + ') no-repeat;');
          }
          if(e_description != null)
              console.log('description: ' + e_description.innerHTML);console.log('------------------');
      }
    }
