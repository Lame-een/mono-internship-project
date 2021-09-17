import DefaultCover from '../Assets/Img/default_cover.png'
import React from 'react';

export default function Cover(props) {

  let displayImg;
  if (props.src != null) {
    displayImg = <img className={props.className} src={props.src} alt={props.alt} />;
  } else {
    displayImg = <img className={props.className} src={DefaultCover} alt={props.alt} />;
  }

  return (
    <div>
      {displayImg}
    </div>
  );
}