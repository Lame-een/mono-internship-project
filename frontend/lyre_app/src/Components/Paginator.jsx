import React from 'react'
import { useHistory, useParams, useLocation } from 'react-router';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';


//USAGE EXAMPLE:
//<Paginator baseUrl="./song" maxPage="6"/>
//MUST be used with a router with a :page parameter
export default function Paginator(props) {

    let page = parseInt(useParams("page").page);
    let maxPage = props.maxPage ?? 10;
    let baseUrl = props.baseUrl;

    let pageList = [];
    let pageRangeStart = Math.max(1, page - 2);
    let pageRangeEnd = Math.min(pageRangeStart + 4, maxPage);
    pageRangeStart = Math.max(1, pageRangeEnd - 4);

    for(let i = pageRangeStart; i <= pageRangeEnd; i++){
        pageList.push(<PaginationItem active={i == page}>
                        <PaginationLink href={getLink(i)}>
                            {i}
                        </PaginationLink>
                    </PaginationItem>);
    }


    function getLink(pageNum) {
        return '../' + baseUrl + '/' + pageNum;
    }

    return (
        <Pagination aria-label="Select page">
            <PaginationItem>
                <PaginationLink first href={getLink(1)} />
            </PaginationItem>
            <PaginationItem disabled={page < 2}>
                <PaginationLink previous href={getLink(page - 1)} />
            </PaginationItem>

            {pageList}

            <PaginationItem disabled={page == maxPage}>
                <PaginationLink next href={getLink(page + 1)} />
            </PaginationItem>
            <PaginationItem>
                <PaginationLink last href={getLink(maxPage)} />
            </PaginationItem>
        </Pagination>
    );
}