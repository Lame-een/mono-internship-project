import React from 'react'
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';


//USAGE EXAMPLE:
//<Paginator baseUrl="./song" maxPage="6"/>
//MUST be used with a router with a :page parameter
export default function QueryPaginator(props) {

    const page = parseInt(props.page);
    const pageChange = props.pageChange;
    const morePagesExist = props.pagesExist;


    return (
        <Pagination className={props.className} aria-label="Select page">
            <PaginationItem disabled={page < 2}>
                <PaginationLink onClick={() => {pageChange(page-1)}}>Previous</PaginationLink>
            </PaginationItem>
            
            <span id="pageDisplay">
                {page}
            </span>

            <PaginationItem disabled={!morePagesExist}>
                <PaginationLink onClick={() => {pageChange(page+1)}}>Next</PaginationLink>
            </PaginationItem>
        </Pagination>
    );
}