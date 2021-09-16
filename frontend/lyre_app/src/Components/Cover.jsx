import DefaultCover from '../Assets/Img/default_cover.png'
import React from 'react';

export default function Cover(props) {

  let displayImg;
  if (props.src) {
    displayImg = <img src={props.src} alt={props.alt} />;
  } else {
    displayImg = <img src={DefaultCover} alt={props.alt} />;
  }

  return (
    <>
      {displayImg}
    </>
  );
}